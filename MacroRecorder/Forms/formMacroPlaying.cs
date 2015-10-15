using MacroRecorder.Macro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroRecorder.Forms
{
    public partial class formMacroPlaying : Form
    {
        public formMacroPlaying(IMacroEvent[] events)
        {
            InitializeComponent();


            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - this.Width, Screen.PrimaryScreen.WorkingArea.Bottom - this.Height);

            new Thread(() =>
            {
                foreach(IMacroEvent e in events)
                {
                    e.ExecuteEvent();
                }
                Invoke((MethodInvoker)delegate()
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                });
            }).Start();
        }

        private void formMacroPlaying_Load(object sender, EventArgs e)
        {

        }
    }
}
