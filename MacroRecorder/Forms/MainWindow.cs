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
    public partial class MainWindow : Form
    {
        MRecorder Recorder = new MRecorder();
        List<IMacroEvent> CurrentMacro = new List<IMacroEvent>();
        public MainWindow()
        {
            InitializeComponent();
            Recorder.OnEvent += Recorder_OnEvent;
        }

        void Recorder_OnEvent(IMacroEvent mEvent)
        {
            ListViewItem i = new ListViewItem(mEvent.GetEventType());
            i.SubItems.Add(mEvent.GetEventString());
            i.Tag = mEvent;
            lvEvents.Items.Add(i);
            CurrentMacro.Add(mEvent);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
        }
        private void recordANewMacroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(formNewMacro newMacro = new formNewMacro())
            {
                if (newMacro.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                using(formMacroNotify mn = new formMacroNotify(Recorder, newMacro.RecordKeyboard, newMacro.RecordMouse, newMacro.DelayBeforeRecord))
                {
                    CurrentMacro.Clear();
                    Recorder.ClearList();
                    lvEvents.Items.Clear();
                    this.Hide();
                    mn.ShowDialog();
                    this.Show();
                }
            }
        }

        private void playMacroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentMacro.Count < 1)
                return;
            using(formMacroPlaying mp = new formMacroPlaying(CurrentMacro.ToArray()))
            {
                this.Hide();
                mp.ShowDialog();
                this.Show();
            }
        }

        private void removeSelectedEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lvEvents.SelectedItems.Count > 0)
            {
                foreach (ListViewItem i in lvEvents.SelectedItems)
                {
                   // ListViewItem i = lvEvents.SelectedItems[0];
                    IMacroEvent mEvent = (IMacroEvent)i.Tag;
                    CurrentMacro.Remove(mEvent);
                    Recorder.Remove(mEvent);
                    lvEvents.Items.Remove(i);
                }
            }
        }
    }
}
