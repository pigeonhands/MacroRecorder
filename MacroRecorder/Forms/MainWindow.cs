using MacroRecorder.Macro;
using MacroRecorder.Macro.Events;
using MacroRecorder.Macro.Structs;
using MacroRecorder.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroRecorder.Forms
{
    /// <summary>
    /// Made By BahNahNah
    /// uid=2388291
    /// </summary>
    public partial class MainWindow : Form
    {
        MRecorder Recorder = new MRecorder(false);
        List<IMacroEvent> CurrentMacro = new List<IMacroEvent>();
        List<ListViewItem> SelectedItems = new List<ListViewItem>();
        public MainWindow()
        {
            InitializeComponent();
            Recorder.OnEvent += Recorder_OnEvent;
        }

        void ClearCurrent()
        {
            CurrentMacro.Clear();
            lvEvents.Items.Clear();
        }

        void Recorder_OnEvent(IMacroEvent mEvent)
        {
            AddEvent(mEvent);
        }

        void AddEvent(IMacroEvent mEvent)
        {
            ListViewItem i = new ListViewItem(mEvent.GetEventType());
            i.SubItems.Add(mEvent.GetEventString());
            i.ImageKey = mEvent.GetEventType();
            i.Tag = mEvent;
            lvEvents.Items.Add(i);
            CurrentMacro.Add(mEvent);
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            ImageList il = new ImageList();
            il.Images.Add("Mouse", Resources.mouse);
            il.Images.Add("Keyboard", Resources.keyboard);
            il.Images.Add("Delay", Resources.time);
            lvEvents.SmallImageList = il;
        }
        private void recordANewMacroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(formNewMacro newMacro = new formNewMacro())
            {
                if (newMacro.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                Recorder.MouseMovementCaptureDelay = newMacro.MouseMovementCaptureDelay;
                Recorder.CaptureMouseMovements = newMacro.CaptureMouseMovements;

                using(formMacroNotify mn = new formMacroNotify(Recorder, newMacro.RecordKeyboard, newMacro.RecordMouse, newMacro.DelayBeforeRecord))
                {
                    ClearCurrent();
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

        private void saveMacroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            using(SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Macro File|*.bmr";
                if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                path = sfd.FileName;
            }

            using(FileStream fs = new FileStream(path, FileMode.Create))
            using(BinaryWriter br = new BinaryWriter(fs))
            {
                br.Write(CurrentMacro.Count);
                foreach(IMacroEvent me in CurrentMacro)
                {
                    Type eventType = me.GetType();
                    if(eventType == typeof(MacroEvent_Delay))
                    {
                        MacroEvent_Delay dEvent = (MacroEvent_Delay)me;
                        br.Write((byte)MacroEventType.Delay);
                        br.Write(dEvent.DelayMS);
                    }

                    if (eventType == typeof(MacroEvent_Keyboard))
                    {
                        MacroEvent_Keyboard kEvent = (MacroEvent_Keyboard)me;
                        br.Write((byte)MacroEventType.Keyboard);
                        br.Write((int)kEvent.EventType);
                        br.Write(kEvent.Event.vKeyCode);
                        br.Write(kEvent.Event.scanCode);
                        br.Write(kEvent.Event.Flags);
                    }
                    if (eventType == typeof(MacroEvent_Mouse))
                    {
                        MacroEvent_Mouse mEvent = (MacroEvent_Mouse)me;
                        br.Write((byte)MacroEventType.Mouse);
                        br.Write((int)mEvent.Button);
                        br.Write(mEvent.Event.mouseData);
                        br.Write(mEvent.Event.Location.X);
                        br.Write(mEvent.Event.Location.Y);
                        br.Write(mEvent.Event.Flags);
                    }
                }
            }
            MessageBox.Show("Macro saved");
        }

        private void loadAMacroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Macro File|*.bmr";
                if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                filePath = ofd.FileName;
            }
            try
            {
                IMacroEvent[] loadedEvents = null;
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                using (BinaryReader br = new BinaryReader(fs))
                {
                    loadedEvents = new IMacroEvent[br.ReadInt32()];
                    int eventIndex = 0;
                    while(fs.Position != fs.Length)
                    {
                        MacroEventType mType = (MacroEventType)br.ReadByte();
                        if(mType == MacroEventType.Delay)
                        {
                            loadedEvents[eventIndex] = new MacroEvent_Delay(br.ReadInt32());
                        }

                        if(mType == MacroEventType.Keyboard)
                        {
                            eKeyboardEvent kbEvent = (eKeyboardEvent)br.ReadInt32();
                            KeyboardEvent eventData = new KeyboardEvent();
                            eventData.vKeyCode = br.ReadUInt32();
                            eventData.scanCode = br.ReadUInt32();
                            eventData.Flags = br.ReadUInt32();
                            eventData.Time = 0;
                            eventData.dwExtraInfo = WinApi.GetMessageExtraInfo();
                            loadedEvents[eventIndex] = new MacroEvent_Keyboard(kbEvent, eventData);
                        }

                        if(mType == MacroEventType.Mouse)
                        {
                            eMouseButton mButton = (eMouseButton)br.ReadInt32();
                            MouseEvent mEvent = new MouseEvent();
                            mEvent.mouseData = br.ReadUInt32();
                            mEvent.Location = new mPoint();
                            mEvent.Location.X = br.ReadInt32();
                            mEvent.Location.Y = br.ReadInt32();
                            mEvent.Flags = br.ReadUInt32();
                            loadedEvents[eventIndex] = new MacroEvent_Mouse(mEvent, mButton);
                        }
                        eventIndex++;
                    }
                }
                ClearCurrent();
                foreach (IMacroEvent lEvent in loadedEvents)
                    AddEvent(lEvent);
                MessageBox.Show("Loaded successfully");
            }
            catch
            {
                MessageBox.Show("Failed to load macro.");
            }
        }

        private void selectItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvEvents.SelectedItems.Count > 0)
            {
                lvEvents.ContextMenuStrip = cmEdit;
                foreach (ListViewItem i in lvEvents.SelectedItems)
                {
                    i.ForeColor = Color.Red;
                    SelectedItems.Add(i);
                }
            }
        }

        private void deselectToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in SelectedItems)
            {
                i.ForeColor = Color.Black;
            }
            SelectedItems.Clear();
            lvEvents.ContextMenuStrip = cmMacro;
        }

        private void selectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvEvents.SelectedItems.Count > 0)
            {
                foreach (ListViewItem i in lvEvents.SelectedItems)
                {
                    if(SelectedItems.Contains(i))
                    {
                        i.ForeColor = Color.Black;
                        SelectedItems.Remove(i);
                    }
                }
                if(SelectedItems.Count < 1)
                {
                    lvEvents.ContextMenuStrip = cmMacro;
                }
            }
        }

        private void moveHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvEvents.SelectedItems.Count > 0)
            {
                int moveIndex = lvEvents.SelectedIndices[0];
                for (int i = SelectedItems.Count-1; i >= 0; i-- )
                {
                    IMacroEvent mEvent = (IMacroEvent)SelectedItems[i].Tag;

                    lvEvents.Items.Remove(SelectedItems[i]);
                    CurrentMacro.Remove(mEvent);

                    lvEvents.Items.Insert(moveIndex, SelectedItems[i]);
                    CurrentMacro.Insert(moveIndex, mEvent);
                }
            }
        }
    }

    public enum MacroEventType : byte
    {
        Mouse,
        Keyboard,
        Delay
    }
}
