namespace Motor_Control
{
    partial class Motor_Control_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Counter_In_textBox = new System.Windows.Forms.TextBox();
            this.Sampling_Period_textBox = new System.Windows.Forms.TextBox();
            this.Frequency_textBox = new System.Windows.Forms.TextBox();
            this.Velocity_textBox = new System.Windows.Forms.TextBox();
            this.Position_textBox = new System.Windows.Forms.TextBox();
            this.Position_Ref_textBox = new System.Windows.Forms.TextBox();
            this.Velocity_Ref_textBox = new System.Windows.Forms.TextBox();
            this.Current_In_textBox = new System.Windows.Forms.TextBox();
            this.Reset_Position_button = new System.Windows.Forms.Button();
            this.Acceleration_Ref_textBox = new System.Windows.Forms.TextBox();
            this.Command_textBox = new System.Windows.Forms.TextBox();
            this.Enable_checkBox = new System.Windows.Forms.CheckBox();
            this.KP_trackBar = new System.Windows.Forms.TrackBar();
            this.TI_trackBar = new System.Windows.Forms.TrackBar();
            this.TD_trackBar = new System.Windows.Forms.TrackBar();
            this.Select_Lab_trackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.KP_textBox = new System.Windows.Forms.TextBox();
            this.TI_textBox = new System.Windows.Forms.TextBox();
            this.TD_textBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.KP_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TI_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TD_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Select_Lab_trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Counter_In_textBox
            // 
            this.Counter_In_textBox.Location = new System.Drawing.Point(27, 233);
            this.Counter_In_textBox.Name = "Counter_In_textBox";
            this.Counter_In_textBox.Size = new System.Drawing.Size(100, 20);
            this.Counter_In_textBox.TabIndex = 0;
            // 
            // Sampling_Period_textBox
            // 
            this.Sampling_Period_textBox.Location = new System.Drawing.Point(27, 289);
            this.Sampling_Period_textBox.Name = "Sampling_Period_textBox";
            this.Sampling_Period_textBox.Size = new System.Drawing.Size(100, 20);
            this.Sampling_Period_textBox.TabIndex = 1;
            // 
            // Frequency_textBox
            // 
            this.Frequency_textBox.Location = new System.Drawing.Point(27, 345);
            this.Frequency_textBox.Name = "Frequency_textBox";
            this.Frequency_textBox.Size = new System.Drawing.Size(100, 20);
            this.Frequency_textBox.TabIndex = 2;
            // 
            // Velocity_textBox
            // 
            this.Velocity_textBox.Location = new System.Drawing.Point(346, 345);
            this.Velocity_textBox.Name = "Velocity_textBox";
            this.Velocity_textBox.Size = new System.Drawing.Size(100, 20);
            this.Velocity_textBox.TabIndex = 3;
            // 
            // Position_textBox
            // 
            this.Position_textBox.Location = new System.Drawing.Point(502, 343);
            this.Position_textBox.Name = "Position_textBox";
            this.Position_textBox.Size = new System.Drawing.Size(100, 20);
            this.Position_textBox.TabIndex = 4;
            // 
            // Position_Ref_textBox
            // 
            this.Position_Ref_textBox.Location = new System.Drawing.Point(502, 287);
            this.Position_Ref_textBox.Name = "Position_Ref_textBox";
            this.Position_Ref_textBox.Size = new System.Drawing.Size(100, 20);
            this.Position_Ref_textBox.TabIndex = 5;
            // 
            // Velocity_Ref_textBox
            // 
            this.Velocity_Ref_textBox.Location = new System.Drawing.Point(346, 289);
            this.Velocity_Ref_textBox.Name = "Velocity_Ref_textBox";
            this.Velocity_Ref_textBox.Size = new System.Drawing.Size(100, 20);
            this.Velocity_Ref_textBox.TabIndex = 6;
            // 
            // Current_In_textBox
            // 
            this.Current_In_textBox.Location = new System.Drawing.Point(170, 236);
            this.Current_In_textBox.Name = "Current_In_textBox";
            this.Current_In_textBox.Size = new System.Drawing.Size(100, 20);
            this.Current_In_textBox.TabIndex = 7;
            // 
            // Reset_Position_button
            // 
            this.Reset_Position_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reset_Position_button.Location = new System.Drawing.Point(645, 340);
            this.Reset_Position_button.Name = "Reset_Position_button";
            this.Reset_Position_button.Size = new System.Drawing.Size(100, 23);
            this.Reset_Position_button.TabIndex = 8;
            this.Reset_Position_button.Text = "Reset Position";
            this.Reset_Position_button.UseVisualStyleBackColor = true;
            this.Reset_Position_button.Click += new System.EventHandler(this.Reset_Position_button_Click);
            // 
            // Acceleration_Ref_textBox
            // 
            this.Acceleration_Ref_textBox.Location = new System.Drawing.Point(172, 289);
            this.Acceleration_Ref_textBox.Name = "Acceleration_Ref_textBox";
            this.Acceleration_Ref_textBox.Size = new System.Drawing.Size(100, 20);
            this.Acceleration_Ref_textBox.TabIndex = 9;
            // 
            // Command_textBox
            // 
            this.Command_textBox.Location = new System.Drawing.Point(172, 345);
            this.Command_textBox.Name = "Command_textBox";
            this.Command_textBox.Size = new System.Drawing.Size(100, 20);
            this.Command_textBox.TabIndex = 10;
            // 
            // Enable_checkBox
            // 
            this.Enable_checkBox.AutoSize = true;
            this.Enable_checkBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Enable_checkBox.Location = new System.Drawing.Point(401, 12);
            this.Enable_checkBox.Name = "Enable_checkBox";
            this.Enable_checkBox.Size = new System.Drawing.Size(56, 17);
            this.Enable_checkBox.TabIndex = 11;
            this.Enable_checkBox.Text = "Enable";
            this.Enable_checkBox.UseVisualStyleBackColor = true;
            // 
            // KP_trackBar
            // 
            this.KP_trackBar.Location = new System.Drawing.Point(23, 41);
            this.KP_trackBar.Maximum = 100;
            this.KP_trackBar.Name = "KP_trackBar";
            this.KP_trackBar.Size = new System.Drawing.Size(251, 45);
            this.KP_trackBar.TabIndex = 12;
            // 
            // TI_trackBar
            // 
            this.TI_trackBar.Location = new System.Drawing.Point(23, 92);
            this.TI_trackBar.Maximum = 100;
            this.TI_trackBar.Minimum = 1;
            this.TI_trackBar.Name = "TI_trackBar";
            this.TI_trackBar.Size = new System.Drawing.Size(251, 45);
            this.TI_trackBar.TabIndex = 13;
            this.TI_trackBar.Value = 1;
            // 
            // TD_trackBar
            // 
            this.TD_trackBar.Location = new System.Drawing.Point(23, 153);
            this.TD_trackBar.Maximum = 100;
            this.TD_trackBar.Name = "TD_trackBar";
            this.TD_trackBar.Size = new System.Drawing.Size(251, 45);
            this.TD_trackBar.TabIndex = 14;
            // 
            // Select_Lab_trackBar
            // 
            this.Select_Lab_trackBar.Location = new System.Drawing.Point(401, 41);
            this.Select_Lab_trackBar.Maximum = 4;
            this.Select_Lab_trackBar.Minimum = 1;
            this.Select_Lab_trackBar.Name = "Select_Lab_trackBar";
            this.Select_Lab_trackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Select_Lab_trackBar.Size = new System.Drawing.Size(45, 129);
            this.Select_Lab_trackBar.TabIndex = 15;
            this.Select_Lab_trackBar.Value = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Counter ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Sampling Period (s)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Frequency (Hz)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Current (A)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(343, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Reference Velocity (deg/s)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(345, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Velocity (deg/s)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(499, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Reference Position (deg)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(499, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Position (deg)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(169, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(166, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Reference Acceleration (deg/s/s)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(169, 329);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Command (V)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(289, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "KP";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(289, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "TI";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(289, 153);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "TD";
            // 
            // KP_textBox
            // 
            this.KP_textBox.Location = new System.Drawing.Point(316, 38);
            this.KP_textBox.Name = "KP_textBox";
            this.KP_textBox.Size = new System.Drawing.Size(41, 20);
            this.KP_textBox.TabIndex = 29;
            // 
            // TI_textBox
            // 
            this.TI_textBox.Location = new System.Drawing.Point(316, 92);
            this.TI_textBox.Name = "TI_textBox";
            this.TI_textBox.Size = new System.Drawing.Size(41, 20);
            this.TI_textBox.TabIndex = 30;
            // 
            // TD_textBox
            // 
            this.TD_textBox.Location = new System.Drawing.Point(317, 150);
            this.TD_textBox.Name = "TD_textBox";
            this.TD_textBox.Size = new System.Drawing.Size(41, 20);
            this.TD_textBox.TabIndex = 31;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(439, 150);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "OPEN LOOP";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(439, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "VELOCITY CONTROL";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(440, 82);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "POSITION CONTROL";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(440, 45);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 35;
            this.label17.Text = "TRACKING";
            // 
            // Motor_Control_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 394);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.TD_textBox);
            this.Controls.Add(this.TI_textBox);
            this.Controls.Add(this.KP_textBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Select_Lab_trackBar);
            this.Controls.Add(this.TD_trackBar);
            this.Controls.Add(this.TI_trackBar);
            this.Controls.Add(this.KP_trackBar);
            this.Controls.Add(this.Enable_checkBox);
            this.Controls.Add(this.Command_textBox);
            this.Controls.Add(this.Acceleration_Ref_textBox);
            this.Controls.Add(this.Reset_Position_button);
            this.Controls.Add(this.Current_In_textBox);
            this.Controls.Add(this.Velocity_Ref_textBox);
            this.Controls.Add(this.Position_Ref_textBox);
            this.Controls.Add(this.Position_textBox);
            this.Controls.Add(this.Velocity_textBox);
            this.Controls.Add(this.Frequency_textBox);
            this.Controls.Add(this.Sampling_Period_textBox);
            this.Controls.Add(this.Counter_In_textBox);
            this.Name = "Motor_Control_Form";
            this.Text = "Motor Control";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Motor_Control_Form_FormClosed);
            this.Load += new System.EventHandler(this.Motor_Control_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KP_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TI_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TD_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Select_Lab_trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Counter_In_textBox;
        private System.Windows.Forms.TextBox Sampling_Period_textBox;
        private System.Windows.Forms.TextBox Frequency_textBox;
        private System.Windows.Forms.TextBox Velocity_textBox;
        private System.Windows.Forms.TextBox Position_textBox;
        private System.Windows.Forms.TextBox Position_Ref_textBox;
        private System.Windows.Forms.TextBox Velocity_Ref_textBox;
        private System.Windows.Forms.TextBox Current_In_textBox;
        private System.Windows.Forms.Button Reset_Position_button;
        private System.Windows.Forms.TextBox Acceleration_Ref_textBox;
        private System.Windows.Forms.TextBox Command_textBox;
        private System.Windows.Forms.CheckBox Enable_checkBox;
        private System.Windows.Forms.TrackBar KP_trackBar;
        private System.Windows.Forms.TrackBar TI_trackBar;
        private System.Windows.Forms.TrackBar TD_trackBar;
        private System.Windows.Forms.TrackBar Select_Lab_trackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox KP_textBox;
        private System.Windows.Forms.TextBox TI_textBox;
        private System.Windows.Forms.TextBox TD_textBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}

