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

        public formNewMacro()
        {
            InitializeComponent();
        }

        private void formNewMacro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(rbRecordKeyboard.Checked)
            {
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
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
