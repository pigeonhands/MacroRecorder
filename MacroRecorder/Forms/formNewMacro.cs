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
    public partial class formNewMacro : Form
    {
        public bool RecordMouse { get; private set; }
        public bool RecordKeyboard { get; private set; }
        public int DelayBeforeRecord { get; private set; }
        public int MouseMovementCaptureDelay { get; private set; }
        public bool CaptureMouseMovements { get; private set; }

        public formNewMacro()
        {
            InitializeComponent();
        }

        private void formNewMacro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CaptureMouseMovements = cbCaptureMouseMovement.Checked;
            if(rbRecordKeyboard.Checked)
            {
                CaptureMouseMovements = false;
                RecordKeyboard = true;
                RecordMouse = false;
            }
            if(rbRecordMouse.Checked)
            {
                RecordMouse = true;
                RecordKeyboard = false;
            }
            if(rbRecordBoth.Checked)
            {
                RecordMouse = true;
                RecordKeyboard = true;
            }
            DelayBeforeRecord = (int)nudRecordDelay.Value * 100;
            MouseMovementCaptureDelay = (tbMouseSmothness.Maximum + 1) - tbMouseSmothness.Value;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblSmoothness.Text = tbMouseSmothness.Value.ToString();
        }

        private void rbRecordKeyboard_CheckedChanged(object sender, EventArgs e)
        {
            gbMouseSettings.Enabled = !rbRecordKeyboard.Checked;
        }
    }
}
