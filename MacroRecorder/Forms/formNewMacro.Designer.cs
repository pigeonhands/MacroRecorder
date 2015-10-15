namespace MacroRecorder.Forms
{
    partial class formNewMacro
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbRecordBoth = new System.Windows.Forms.RadioButton();
            this.rbRecordKeyboard = new System.Windows.Forms.RadioButton();
            this.rbRecordMouse = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudRecordDelay = new System.Windows.Forms.NumericUpDown();
            this.gbMouseSettings = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCaptureMouseMovement = new System.Windows.Forms.CheckBox();
            this.lblSmoothness = new System.Windows.Forms.Label();
            this.tbMouseSmothness = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecordDelay)).BeginInit();
            this.gbMouseSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMouseSmothness)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbRecordBoth);
            this.groupBox1.Controls.Add(this.rbRecordKeyboard);
            this.groupBox1.Controls.Add(this.rbRecordMouse);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Record";
            // 
            // rbRecordBoth
            // 
            this.rbRecordBoth.AutoSize = true;
            this.rbRecordBoth.Checked = true;
            this.rbRecordBoth.Location = new System.Drawing.Point(168, 19);
            this.rbRecordBoth.Name = "rbRecordBoth";
            this.rbRecordBoth.Size = new System.Drawing.Size(47, 17);
            this.rbRecordBoth.TabIndex = 2;
            this.rbRecordBoth.TabStop = true;
            this.rbRecordBoth.Text = "Both";
            this.rbRecordBoth.UseVisualStyleBackColor = true;
            // 
            // rbRecordKeyboard
            // 
            this.rbRecordKeyboard.AutoSize = true;
            this.rbRecordKeyboard.Location = new System.Drawing.Point(80, 19);
            this.rbRecordKeyboard.Name = "rbRecordKeyboard";
            this.rbRecordKeyboard.Size = new System.Drawing.Size(70, 17);
            this.rbRecordKeyboard.TabIndex = 1;
            this.rbRecordKeyboard.Text = "Keyboard";
            this.rbRecordKeyboard.UseVisualStyleBackColor = true;
            this.rbRecordKeyboard.CheckedChanged += new System.EventHandler(this.rbRecordKeyboard_CheckedChanged);
            // 
            // rbRecordMouse
            // 
            this.rbRecordMouse.AutoSize = true;
            this.rbRecordMouse.Location = new System.Drawing.Point(6, 19);
            this.rbRecordMouse.Name = "rbRecordMouse";
            this.rbRecordMouse.Size = new System.Drawing.Size(57, 17);
            this.rbRecordMouse.TabIndex = 0;
            this.rbRecordMouse.Text = "Mouse";
            this.rbRecordMouse.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nudRecordDelay);
            this.groupBox2.Location = new System.Drawing.Point(12, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 54);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Delay before record";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "s";
            // 
            // nudRecordDelay
            // 
            this.nudRecordDelay.Location = new System.Drawing.Point(6, 19);
            this.nudRecordDelay.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudRecordDelay.Name = "nudRecordDelay";
            this.nudRecordDelay.Size = new System.Drawing.Size(191, 20);
            this.nudRecordDelay.TabIndex = 0;
            // 
            // gbMouseSettings
            // 
            this.gbMouseSettings.Controls.Add(this.label2);
            this.gbMouseSettings.Controls.Add(this.cbCaptureMouseMovement);
            this.gbMouseSettings.Controls.Add(this.lblSmoothness);
            this.gbMouseSettings.Controls.Add(this.tbMouseSmothness);
            this.gbMouseSettings.Location = new System.Drawing.Point(12, 132);
            this.gbMouseSettings.Name = "gbMouseSettings";
            this.gbMouseSettings.Size = new System.Drawing.Size(229, 83);
            this.gbMouseSettings.TabIndex = 3;
            this.gbMouseSettings.TabStop = false;
            this.gbMouseSettings.Text = "Mouse Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Smoothness:";
            // 
            // cbCaptureMouseMovement
            // 
            this.cbCaptureMouseMovement.AutoSize = true;
            this.cbCaptureMouseMovement.Checked = true;
            this.cbCaptureMouseMovement.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCaptureMouseMovement.Location = new System.Drawing.Point(14, 15);
            this.cbCaptureMouseMovement.Name = "cbCaptureMouseMovement";
            this.cbCaptureMouseMovement.Size = new System.Drawing.Size(146, 17);
            this.cbCaptureMouseMovement.TabIndex = 2;
            this.cbCaptureMouseMovement.Text = "Capure mouse movement";
            this.cbCaptureMouseMovement.UseVisualStyleBackColor = true;
            // 
            // lblSmoothness
            // 
            this.lblSmoothness.AutoSize = true;
            this.lblSmoothness.Location = new System.Drawing.Point(105, 63);
            this.lblSmoothness.Name = "lblSmoothness";
            this.lblSmoothness.Size = new System.Drawing.Size(25, 13);
            this.lblSmoothness.TabIndex = 1;
            this.lblSmoothness.Text = "900";
            // 
            // tbMouseSmothness
            // 
            this.tbMouseSmothness.Location = new System.Drawing.Point(6, 36);
            this.tbMouseSmothness.Maximum = 1000;
            this.tbMouseSmothness.Minimum = 1;
            this.tbMouseSmothness.Name = "tbMouseSmothness";
            this.tbMouseSmothness.Size = new System.Drawing.Size(217, 45);
            this.tbMouseSmothness.TabIndex = 0;
            this.tbMouseSmothness.Value = 900;
            this.tbMouseSmothness.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // formNewMacro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 248);
            this.Controls.Add(this.gbMouseSettings);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formNewMacro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Record Settings";
            this.Load += new System.EventHandler(this.formNewMacro_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecordDelay)).EndInit();
            this.gbMouseSettings.ResumeLayout(false);
            this.gbMouseSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMouseSmothness)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbRecordBoth;
        private System.Windows.Forms.RadioButton rbRecordKeyboard;
        private System.Windows.Forms.RadioButton rbRecordMouse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudRecordDelay;
        private System.Windows.Forms.GroupBox gbMouseSettings;
        private System.Windows.Forms.Label lblSmoothness;
        private System.Windows.Forms.TrackBar tbMouseSmothness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbCaptureMouseMovement;
    }
}