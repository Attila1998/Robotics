using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PreciseTimer {

    public enum TimerMode {
        OneShot, // for an event with one occurence
        Periodic // for periodically occuring event
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct TimerCaps {
        public int minPeriod; // min supported period (ms)
        public int maxPeriod; // max supported period (ms)
    }

    public sealed class mmTimer : IComponent {
        #region PreciseTimer Members

        #region Delegates
        // Method called by Windows when timer event occurs
        private delegate void MmTimeProc(int id, int msg, int user, int param1, int param2);
        // Methods that raise the event
        private delegate void EventRaiser(EventArgs e);

        #endregion

        #region Win32 Multimedia Timer Functions
        // Get timer capabilities
        [DllImport("winmm.dll")]
        private static extern int timeGetDevCaps(ref TimerCaps caps, int sizeOfTimerCaps);

        // Creates and starts the timer
        [DllImport("winmm.dll")]
        private static extern int timeSetEvent(int delay, int resolution, MmTimeProc proc, int user, int mode);

        //Stops and destroys timer
        [DllImport("winmm.dll")]
        private static extern int timeKillEvent(int id);

        private const int TIMER_NOERROR = 0;
        #endregion

        #region Fields

        private int timerID; // identifier
        private volatile TimerMode mode; // timer mode
        private volatile int period; // period between events in ms
        private volatile int resolution; // resolution in ms
        private MmTimeProc timeProcPeriodic; // periodic event callback
        private MmTimeProc timeProcOneShot; // one shot event callback
        private EventRaiser tickRaiser; // method that raises the tick event
        private bool running = false;
        private volatile bool disposed = false;
        private ISynchronizeInvoke synchronizingObject = null; // object for marshaling events
        private ISite site = null;
        private static TimerCaps caps; // multimedia timer capabilities

        #endregion

        #region Events

        public event EventHandler Started; // Occurs when timer started
        public event EventHandler Stopped; // Occurs when timer stopped
        public event EventHandler Tick; // Occurs when time period elapsed

        #endregion

        #region Constructor

        static mmTimer() {
            timeGetDevCaps(ref caps, Marshal.SizeOf(caps));
        }

        public mmTimer(IContainer container) {

            // Required for Windows.Forms Class Composition Design
            container.Add(this);
            Initialize();
        }

        public mmTimer() {
            Initialize();
        }

        ~mmTimer() {
            if (IsRunning) {
                timeKillEvent(timerID);
            }
        }

        //Initialize timer with default values
        private void Initialize() {
            this.mode = TimerMode.Periodic;
            this.period = Capabilities.minPeriod;
            this.resolution = 1;

            running = false;

            timeProcPeriodic = new MmTimeProc(TimerPeriodicEventCallback);
            timeProcOneShot = new MmTimeProc(TimerOneShotEventCallback);
            tickRaiser = new EventRaiser(OnTick);
        }

        #endregion

        #region Methods

        //Start the timer
        public void Start() {
            #region Require
            if (disposed) {
                throw new ObjectDisposedException("Timer");
            }
            #endregion

            #region Guard
            if (IsRunning) {
                return;
            }
            #endregion

            if (Mode == TimerMode.Periodic) {
                timerID = timeSetEvent(Period, Resolution, timeProcPeriodic, 0, (int)Mode);
            } else {
                timerID = timeSetEvent(Period, Resolution, timeProcOneShot, 0, (int)Mode);
            }

            if (timerID != 0) {
                running = true;
                if (synchronizingObject != null && synchronizingObject.InvokeRequired) {
                    synchronizingObject.BeginInvoke(
                        new EventRaiser(OnStarted),
                        new object[] { EventArgs.Empty });
                } else {
                    OnStarted(EventArgs.Empty);
                }
            } else {
                throw new TimerStartException("Unable to start multimedia Timer.");
            }
        }

        // Stop the timer
        public void Stop() {
            #region Require
            if (disposed) {
                throw new ObjectDisposedException("Timer");
            }
            #endregion

            #region Guard
            if (!running) {
                return;
            }
            #endregion

            int result = timeKillEvent(timerID);
            Debug.Assert(result == TIMER_NOERROR);
            running = false;

            if (synchronizingObject != null && synchronizingObject.InvokeRequired) {
                synchronizingObject.BeginInvoke(
                        new EventRaiser(OnStopped),
                        new object[] { EventArgs.Empty });
            } else {
                OnStopped(EventArgs.Empty);
            }
        }

        #region Callbacks

        // Periodic event callback
        private void TimerPeriodicEventCallback(int id, int msg, int user, int param1, int param2) {
            if (synchronizingObject != null) {
                synchronizingObject.BeginInvoke(tickRaiser, new object[] { EventArgs.Empty });
            } else {
                OnTick(EventArgs.Empty);
            }
        }

        // One shot event callback
        private void TimerOneShotEventCallback(int id, int msg, int user, int param1, int param2) {
            if (synchronizingObject != null) {
                synchronizingObject.BeginInvoke(tickRaiser, new object[] { EventArgs.Empty });
                Stop();
            } else {
                OnTick(EventArgs.Empty);
                Stop();
            }
        }

        #endregion

        #region Event Raiser Methods

        private void OnDisposed(EventArgs e) {
            EventHandler handler = Disposed;

            if (handler != null)
                handler(this, e);
        }

        private void OnStarted(EventArgs e) {
            EventHandler handler = Started;

            if (handler != null)
                handler(this, e);
        }

        private void OnStopped(EventArgs e) {
            EventHandler handler = Stopped;

            if (handler != null)
                handler(this, e);
        }

        private void OnTick(EventArgs e) {
            EventHandler handler = Tick;

            if (handler != null)
                handler(this, e);
        }

        #endregion
        #endregion

        #region Properties

        public ISynchronizeInvoke SynchronizingObject {
            get {
                #region Require
                if (disposed)
                    throw new ObjectDisposedException("Timer");
                #endregion
                return synchronizingObject;
            }
            set {
                #region Require
                if (disposed)
                    throw new ObjectDisposedException("Timer");
                #endregion
                synchronizingObject = value;
            }
        }

        public int Period {
            get {
                #region Require
                if (disposed)
                    throw new ObjectDisposedException("Timer");
                #endregion
                return period;
            }
            set {
                #region Require
                if (disposed)
                    throw new ObjectDisposedException("Timer");
                else if (value < Capabilities.minPeriod || value > Capabilities.maxPeriod)
                    throw new ArgumentOutOfRangeException("Period", value,
                        "Multimedia Timer period out of range.");
                #endregion
                period = value;

                if (IsRunning) {
                    Stop();
                    Start();
                }
            }
        }

        public int Resolution {
            get {
                #region Require
                if (disposed)
                    throw new ObjectDisposedException("Timer");
                #endregion
                return resolution;
            }
            set {
                #region Require
                if (disposed)
                    throw new ObjectDisposedException("Timer");
                else if (value < 0)
                    throw new ArgumentOutOfRangeException("Resolution", value,
                        "Multimedia Timer resolution out of range.");
                #endregion

                resolution = value;

                if (IsRunning) {
                    Stop();
                    Start();
                }
            }
        }

        public TimerMode Mode {
            get {
                #region Require
                if (disposed)
                    throw new ObjectDisposedException("Timer");
                #endregion
                return mode;
            }
            set {
                #region Require
                if (disposed)
                    throw new ObjectDisposedException("Timer");

                #endregion

                mode = value;

                if (IsRunning) {
                    Stop();
                    Start();
                }
            }
        }

        public bool IsRunning {
            get {
                return running;
            }
        }

        public static TimerCaps Capabilities {
            get {
                return caps;
            }
        }

        #endregion
        #endregion

        #region IComponent Members

        public event System.EventHandler Disposed;

        public ISite Site {
            get {
                return site;
            }
            set {
                site = value;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose() {
            #region Guard
            if (disposed)
                return;
            #endregion

            if (IsRunning)
                Stop();

            disposed = true;
            OnDisposed(EventArgs.Empty);
        }

        #endregion

        public class TimerStartException : ApplicationException {
            public TimerStartException(string message) : base(message) {

            }
        }

    }
}
