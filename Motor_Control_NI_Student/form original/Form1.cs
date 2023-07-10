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
        NationalInstruments.DAQmx.Task DOutTask = new NationalInstruments.DAQmx.Task();
        AnalogSingleChannelWriter setAOut;
        DigitalSingleChannelWriter setDOut;
        mmTimer newTimer;

        
        public Motor_Control_Form()
        {
            InitializeComponent();
        }


        private void Motor_Control_Form_Load(object sender, EventArgs e)
        {
            try
            {
                AOutTask.AOChannels.CreateVoltageChannel("Dev1/ao0", "AOut", 0.0, 10.0, AOVoltageUnits.Volts);
                setAOut = new AnalogSingleChannelWriter(AOutTask.Stream);
                DOutTask.DOChannels.CreateChannel("Dev1/port0", "DOut", ChannelLineGrouping.OneChannelForAllLines);
                setDOut = new DigitalSingleChannelWriter(DOutTask.Stream);
            }
            catch (DaqException ex)
            {
                MessageBox.Show(ex.Message);
            }
                newTimer = new mmTimer();
                newTimer.Mode = TimerMode.Periodic;
                newTimer.Resolution = 1;
                newTimer.Period = 36;
                newTimer.Tick += new EventHandler(mmTimer_Tick);
                newTimer.Start();
            
        }

        private void mmTimer_Tick(object sender, EventArgs e)
        {
            UInt32 Enable = 0;
            if (Enable_checkBox.Checked)
                Enable = 1;
            double Command = 0;
            UInt32 Direction = 0;
            int val;
            getTextboxVal("Select_Lab_trackBar", out val);
            switch (val)
            {
                case 1:
                    String SCommand;
                    getTextboxVal("Command_textBox",out SCommand);
                    try{
                        Command=Convert.ToDouble(SCommand);
                    }
                    catch{
                        Command = 0;
                    }
                    break;
            }
            if(Command<0){
                Command *=-1;
                Direction = 1;
            }
            else
                Direction = 0;
            double an_out=Command;
            if(Command>10)
                an_out=10;

            setAOut.WriteSingleSample(true,an_out);
            UInt32 d_out = 0;
            if (Enable == 1)
                d_out |= 0x01;
            if (Direction == 1)
                d_out |= 0x02;

            setDOut.WriteSingleSamplePort(true, d_out);
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

        }

        private void Motor_Control_Form_FormClosed(object sender, FormClosedEventArgs e)
        {

            setAOut.WriteSingleSample(true, 0);
            setDOut.WriteSingleSamplePort(true, 0);
        }
    }
}
