using MacroRecorder.Macro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroRecorder.Forms
{
    public partial class formMacroNotify : Form
    {
        MRecorder Recorder;
        int elapsed = 0;
        int wait = 0;

        bool rKeyboard = false;
        bool rMouse = false;
        Timer delayTimer = new Timer();

        public formMacroNotify(MRecorder _recorder, bool keyboard, bool mouse, int msWait)
        {
            InitializeComponent();
            Recorder = _recorder;
            wait = msWait;

            rKeyboard = keyboard;
            rMouse = mouse;

            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - this.Width, Screen.PrimaryScreen.WorkingArea.Bottom - this.Height);

            if(msWait == 0)
            {
                statusLabel.Text = "Recording";
                statusLabel.ForeColor = Color.Red;
                Recorder.StartRecording(rKeyboard, rMouse);
            }
            else
            {
                statusLabel.Text = string.Format("Waiting {0}ms", wait/100);
                statusLabel.ForeColor = Color.Blue;
                
                delayTimer.Tick += TimerLoop;
                delayTimer.Interval = 1;
                delayTimer.Start();
            }
        }

        void TimerLoop(object sender, EventArgs e)
        {
            elapsed++;
            if(elapsed >= wait)
            {
                ((Timer)sender).Stop();
                statusLabel.Text = "Recording";
                statusLabel.ForeColor = Color.Red;
                Recorder.StartRecording(rKeyboard, rMouse);
            }
            else
            {
                statusLabel.Text = string.Format("Waiting {0}s",(float)(wait-elapsed) / 100);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            delayTimer.Stop();
            Recorder.StopRecording();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void formMacroNotify_Load(object sender, EventArgs e)
        {

        }
    }
}
