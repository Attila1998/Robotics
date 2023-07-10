using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NationalInstruments.DAQmx;
using PreciseTimer;

namespace Motor_Control
{
    public partial class Motor_Control_Form : Form
    {
        NationalInstruments.DAQmx.Task AOutTask = new NationalInstruments.DAQmx.Task();
        AnalogSingleChannelWriter setAOut;
        NationalInstruments.DAQmx.Task DOutTask = new NationalInstruments.DAQmx.Task();
        DigitalSingleChannelWriter setDOut;
        NationalInstruments.DAQmx.Task AInTask = new NationalInstruments.DAQmx.Task();
        AnalogSingleChannelReader getAIn;
        NationalInstruments.DAQmx.Task DInTask = new NationalInstruments.DAQmx.Task();
        DigitalSingleChannelReader getDIn;
        NationalInstruments.DAQmx.Task CInTask = new NationalInstruments.DAQmx.Task();
        CounterSingleChannelReader getCIn;

        mmTimer newTimer;

        DateTime t_k_1 = DateTime.MinValue;
        UInt32 Counter_In_k_1 = 0;
        UInt32 display_counter = 0;
        double vel_k_1 = 0;
        double pos_k_1 = 0;
        double pos;
        double u_k_1 = 0;
        double e_k_1 = 0;
        
        public Motor_Control_Form()
        {
            InitializeComponent();
        }

        private void Motor_Control_Form_Load(object sender, EventArgs e)
        {

            try{
                AOutTask.AOChannels.CreateVoltageChannel("Dev1/ao0", "AOut", 0.0, 10.0, AOVoltageUnits.Volts);
                setAOut = new AnalogSingleChannelWriter(AOutTask.Stream);

                DOutTask.DOChannels.CreateChannel("Dev1/port0", "DOut", ChannelLineGrouping.OneChannelForAllLines);
                setDOut = new DigitalSingleChannelWriter(DOutTask.Stream);

                AInTask.AIChannels.CreateVoltageChannel("Dev1/ai0", "AIn", AITerminalConfiguration.Rse, -10.0, 10.0, AIVoltageUnits.Volts);
                getAIn = new AnalogSingleChannelReader(AInTask.Stream);

                DInTask.DIChannels.CreateChannel("Dev1/port1", "DIn", ChannelLineGrouping.OneChannelForAllLines);
                getDIn = new DigitalSingleChannelReader(DInTask.Stream);

                CInTask.CIChannels.CreateCountEdgesChannel("Dev1/ctr0", "CIn", CICountEdgesActiveEdge.Rising, 0, CICountEdgesCountDirection.Up);
                getCIn = new CounterSingleChannelReader(CInTask.Stream);
                CInTask.Start();
            }
            catch (DaqException ex)
            {
                MessageBox.Show(ex.Message);
            }

            newTimer = new mmTimer();
            newTimer.Mode = TimerMode.Periodic;
            newTimer.Resolution = 1; //ms
            newTimer.Period = 40; //ms
            newTimer.Tick += new EventHandler(mmTimer_Tick);
            newTimer.Start();

        }

        private void mmTimer_Tick(object sender, EventArgs e)
        {
            // Compute Sampling Period
            double T = 0;
            DateTime t_k = DateTime.Now;
            if (t_k_1 != DateTime.MinValue)
            {
                TimeSpan period = t_k - t_k_1;
                T = period.TotalSeconds;
            }
            t_k_1 = t_k;

            // Reads Current
            double Voltage_IN = getAIn.ReadSingleSample();
            double R = 4260; // Ohm - max 4.7 kOhm
            double Current_Division = 0.000377; // A -  min: 325 ; max: 425 typ: 377
            double Current = Voltage_IN / R / Current_Division;

            // Reads Counter
            UInt32 Counter_In = getCIn.ReadSingleSampleUInt32();
            UInt32 Delta_Count = 0;
            if (Counter_In_k_1 <= Counter_In)
            {
                Delta_Count = Counter_In - Counter_In_k_1;
            }
            else
            {
                // If Overflow
                Delta_Count = Counter_In + (UInt32.MaxValue - Counter_In_k_1);
            }
            Counter_In_k_1 = Counter_In;

            // Reads Encoder Direction
            Int32 DigitalIn_Val = getDIn.ReadSingleSamplePortByte();
            Int32 Dir_Ecncoder = DigitalIn_Val & 0x01;

            // Compute Frequency
            double Freqency = 0;
            if (T != 0)
            {
                Freqency = Convert.ToDouble(Delta_Count) / T;
            }

            // Compute Position and Velocity
            double N = 500.0; // Encoder resolution

            double vel = 0;
            if (Dir_Ecncoder == 1)
            {
                vel = Freqency * 360 / N;
            }
            else
            {
                vel = -Freqency * 360 / N;
            }

            pos = pos_k_1 + T * (vel + vel_k_1) / 2;

            vel_k_1 = vel;
            pos_k_1 = pos;


            // Enable
            UInt32 Enable = 0;
            if (Enable_checkBox.Checked)
            {
                Enable = 1;
            }

            int val;
            getTextboxVal("Select_Lab_trackBar", out val);
            string temp;

            double Command = 0;
            UInt32 Direction = 0;


            int KP_int;
            double kp;
            int TI_int;
            double TI;
            int TD_int;
            double TD;


            double u_k, u_k_1 = 0, e_k, e_k_1 = 0;
            string vel_s;
            string pos_s;
            double vel_ref;
            double ref_pos;
            switch (val)
            {
                case 1:
                    // open loop command
                    getTextboxVal("Command_textBox", out temp);
                    try
                    {
                        Command = Convert.ToDouble(temp);
                    }
                    catch
                    {
                        Command = 0;
                    }
                    break;
                case 2:
                    
                    getTextboxVal("KP_trackBar",out KP_int);
                    kp = KP_int*0.00001;
                    getTextboxVal("TI_trackBar",out TI_int);
                    TI = TI_int*0.01;

                    getTextboxVal("Velocity_Ref_textBox", out vel_s);
                    try
                    {
                        vel_ref = Convert.ToDouble(vel_s);
                    }
                    catch
                    {
                        vel_ref = 0;
                    }
                    
                    e_k = vel_ref - vel;
                    u_k = u_k_1 + kp * (e_k - e_k_1 + (T / TI) * e_k);
                    u_k_1 = u_k;
                    e_k_1 = e_k;
                    Command = u_k;
                    setTextboxVal("Command_textBox", Command.ToString());

                    break;

                case 3:
                    double tao = 0.3;
                    getTextboxVal("KP_trackBar", out KP_int);
                    kp = KP_int * 0.01;
                    getTextboxVal("TD_trackBar",out TD_int);
                    TD = TD_int*0.001;
                    
                    getTextboxVal("Position_Ref_textBox", out pos_s);

                    try
                    {
                        ref_pos = Convert.ToDouble(pos_s);
                    }
                    catch
                    {
                        ref_pos = 0;
                    }
                    e_k = ref_pos - pos;
                    u_k = kp * (e_k + (TD / T) * (e_k - e_k_1));
                    if(u_k>0)
                    {
                        u_k += tao;
                    }
                    if (u_k < 0)
                    {
                        u_k -= tao;
                    }
                    Command = u_k;

                    break;
            }

            if (Command < 0)
            {
                Command = -Command;
                Direction = 1;
            }
            else
            {
                Direction = 0;
            }

            double AOut_Val = Command;
            if (AOut_Val < 0)
            {
                AOut_Val = 0;
            }
            if (AOut_Val > 10)
            {
                AOut_Val = 10;
            }
            setAOut.WriteSingleSample(true, AOut_Val);

            // Set Digital Outputs
            UInt32 DOut_Val = 0;
            if (Enable == 1)
            {
                DOut_Val = DOut_Val | 0x01;
            }
            if (Direction == 1)
            {
                DOut_Val = DOut_Val | 0x02;
            }
            setDOut.WriteSingleSamplePort(true, DOut_Val);

            // Display Numerical Values
            display_counter++;
            if (display_counter >= 10)
            {
                setTextboxVal("Sampling_Period_textBox", T.ToString());
                setTextboxVal("Counter_In_textBox", Counter_In.ToString());
                setTextboxVal("Frequency_textBox", Freqency.ToString("F"));
                setTextboxVal("Velocity_textBox", vel.ToString("F"));
                setTextboxVal("Position_textBox", pos.ToString("F"));
                setTextboxVal("Current_In_textBox", Current.ToString());
                display_counter = 0;
            }

        }

        public void getTextboxVal(string box, out int val)
        {
            if (box.CompareTo("Select_Lab_trackBar") == 0)
                val = (int)Select_Lab_trackBar.Invoke(new Func<int>(() => Select_Lab_trackBar.Value));
            else if (box.CompareTo("KP_trackBar") == 0)
                val = (int)KP_trackBar.Invoke(new Func<int>(() => KP_trackBar.Value));
            else if (box.CompareTo("TD_trackBar") == 0)
                val = (int)TD_trackBar.Invoke(new Func<int>(() => TD_trackBar.Value));
            else if (box.CompareTo("TI_trackBar") == 0)
                val = (int)TI_trackBar.Invoke(new Func<int>(() => TI_trackBar.Value));
            else
                val = 0;
                
        }

        public void getTextboxVal(string box, out string val) {
            if (box.CompareTo("Command_textBox") == 0)
                val = (string)Command_textBox.Invoke(new Func<string>(() => Command_textBox.Text));
            else if (box.CompareTo("Velocity_Ref_textBox") == 0)
                val = (string)Velocity_Ref_textBox.Invoke(new Func<string>(() => Velocity_Ref_textBox.Text));
            else if (box.CompareTo("Position_Ref_textBox") == 0)
                val = (string)Position_Ref_textBox.Invoke(new Func<string>(() => Position_Ref_textBox.Text));
            else
                val = null;
        }

        public void setTextboxVal(string box, string val)
        {
            if (InvokeRequired)
                this.Invoke(new Action<string, string>(setTextboxVal), new object[] {box, val});

            if (box.CompareTo("Sampling_Period_textBox")==0)
            {
                Sampling_Period_textBox.Text = val;
            }
            if (box.CompareTo("Counter_In_textBox") == 0)
            {
                Counter_In_textBox.Text = val;
            }
            if (box.CompareTo("Frequency_textBox") == 0)
            {
                Frequency_textBox.Text = val;
            }
            if (box.CompareTo("Velocity_textBox") == 0)
            {
                Velocity_textBox.Text = val;
            }
            if (box.CompareTo("Position_textBox") == 0)
            {
                Position_textBox.Text = val;
            }
            if (box.CompareTo("Current_In_textBox") == 0)
            {
                Current_In_textBox.Text = val;
            }
            if (box.CompareTo("KP_textBox") == 0)
            {
                KP_textBox.Text = val;
            }
            if (box.CompareTo("TI_textBox") == 0)
            {
                TI_textBox.Text = val;
            }
            if (box.CompareTo("TD_textBox") == 0)
            {
                TD_textBox.Text = val;
            }
            if (box.CompareTo("Command_textBox") == 0)
            {
                Command_textBox.Text = val;
            }
            if (box.CompareTo("Acceleration_Ref_textBox") == 0)
            {
                Acceleration_Ref_textBox.Text = val;
            }
            if (box.CompareTo("Velocity_Ref_textBox") == 0)
            {
                Velocity_Ref_textBox.Text = val;
            }
            if (box.CompareTo("Position_Ref_textBox") == 0)
            {
                Position_Ref_textBox.Text = val;
            }
        }

        private void Reset_Position_button_Click(object sender, EventArgs e)
        {
            pos_k_1 = 0;
            pos = 0;
        }

        private void Motor_Control_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            setAOut.WriteSingleSample(true, 0);
            setDOut.WriteSingleSamplePort(true, 0);
        }
    }
}
