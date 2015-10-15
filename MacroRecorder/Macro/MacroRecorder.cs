using MacroRecorder.Macro.Events;
using MacroRecorder.Macro.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroRecorder.Macro
{
    /// <summary>
    /// Made By BahNahNah
    /// uid=2388291
    /// </summary>
    public class MRecorder
    {
        #region " Delegates "

        public delegate void OnEventCallback(IMacroEvent mEvent);

        #endregion

        #region " Events "

        public event OnEventCallback OnEvent;

        #endregion

        #region " Properties "

        public bool RecordingStopped { get { return ThreadExited; } }
        public IMacroEvent[] RecordedEvents { get { return EventList.ToArray(); } }

        #endregion

        #region " Fields "

        List<IMacroEvent> EventList = new List<IMacroEvent>();
        Thread threadTask = null;
        DateTime delayBegin = DateTime.Now;
        bool ThreadRunning = false;
        bool ThreadExited = true;
        bool AcceptMouseMovement = false;
        bool PopulateInternalEventList = true;

        bool RecordKeyboard = false;
        bool RecordMouse = false;

        HookCallback KBCallback;
        HookCallback MCallback;

        IntPtr KeyboardHook = IntPtr.Zero;
        IntPtr MouseHook = IntPtr.Zero;
        
        #endregion

        #region " Functions "

        public MRecorder()
        {
            KBCallback = new HookCallback(KeyboardEventCallback);
            MCallback = new HookCallback(MouseEventCallback);
        }

        public MRecorder(bool _populateinternaleventlist)
        {
            KBCallback = new HookCallback(KeyboardEventCallback);
            MCallback = new HookCallback(MouseEventCallback);
            PopulateInternalEventList = _populateinternaleventlist;
        }

        public void Remove(IMacroEvent mEvent)
        {
            EventList.Remove(mEvent);
        }
        public void Play()
        {
            Play(RecordedEvents);
        }

        public void Play(IMacroEvent[] events)
        {
            foreach(IMacroEvent e in events)
            {
                e.ExecuteEvent();
            }
        }

        public void StopRecording()
        {
            if (ThreadRunning)
            {
                ThreadRunning = false;
            }
            else
            {
                if (RecordKeyboard)
                    WinApi.UnhookWindowsHookEx(KeyboardHook);
                if (RecordMouse)
                    WinApi.UnhookWindowsHookEx(MouseHook);
                ThreadExited = true;
            }
        }
        public void StartRecording(bool _recordKeyboard, bool _recordMouse)
        {
            if(ThreadExited)
            {
                RecordKeyboard = _recordKeyboard;
                RecordMouse = _recordMouse;
                if (RecordKeyboard)
                    KeyboardHook = WinApi.SetWindowsHookEx(13, KBCallback, IntPtr.Zero, 0);
                if (RecordMouse)
                    MouseHook = WinApi.SetWindowsHookEx(14, MCallback, IntPtr.Zero, 0);
                ThreadExited = false;
                if (RecordMouse)
                {
                    ThreadRunning = true;
                    AcceptMouseMovement = false;
                    threadTask = new Thread(() =>
                    {
                        delayBegin = DateTime.Now;
                        while (ThreadRunning)
                        {
                            Thread.Sleep(10);
                            AcceptMouseMovement = true;
                        }
                        if (RecordKeyboard)
                            WinApi.UnhookWindowsHookEx(KeyboardHook);
                        if (RecordMouse)
                            WinApi.UnhookWindowsHookEx(MouseHook);
                        ThreadExited = true;
                    });
                    threadTask.Start();
                }
            }
        }
        public void ClearList()
        {
            EventList.Clear();
        }

        #endregion

        #region " Callbacks "

        private IntPtr MouseEventCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if(!(nCode < 0))
            {
                lock(this)
                {
                    eMouseButton button = (eMouseButton)wParam;
                    if(button == eMouseButton.MOVE && !AcceptMouseMovement)
                        return WinApi.CallNextHookEx(MouseHook, nCode, wParam, lParam);

                    MouseEvent eventData = (MouseEvent)Marshal.PtrToStructure(lParam, typeof(MouseEvent));
                    DateTime cTime = DateTime.Now;
                    int delay = (cTime - delayBegin).Milliseconds;

                    MacroEvent_Delay dEvent = new MacroEvent_Delay(delay);
                    MacroEvent_Mouse mEvent = new MacroEvent_Mouse(eventData, button);

                    if (PopulateInternalEventList)
                    {
                        EventList.Add(dEvent);
                        EventList.Add(mEvent);
                    }

                    if (OnEvent != null)
                    {
                        OnEvent(dEvent);
                        OnEvent(mEvent);
                    }

                    AcceptMouseMovement = false;
                    delayBegin = cTime;
                }
            }
            return WinApi.CallNextHookEx(MouseHook, nCode, wParam, lParam);
        }

        private IntPtr KeyboardEventCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            eKeyboardEvent eKB = (eKeyboardEvent)wParam;
            if(!(nCode < 0) && (eKB == eKeyboardEvent.KeyDown || eKB == eKeyboardEvent.KeyUp))
            {
                lock (this)
                {
                    KeyboardEvent kbEvent = (KeyboardEvent)Marshal.PtrToStructure(lParam, typeof(KeyboardEvent));
                    DateTime cTime = DateTime.Now;
                    int delay = (cTime - delayBegin).Milliseconds;

                    MacroEvent_Delay dEvent = new MacroEvent_Delay(delay);
                    MacroEvent_Keyboard kEvent = new MacroEvent_Keyboard(eKB, kbEvent);

                    if (PopulateInternalEventList)
                    {
                        EventList.Add(dEvent);
                        EventList.Add(kEvent);
                    }

                    if (OnEvent != null)
                    {
                        OnEvent(dEvent);
                        OnEvent(kEvent);
                    }
                    delayBegin = cTime;
                }
            }
            return WinApi.CallNextHookEx(KeyboardHook, nCode, wParam, lParam);
        }

        #endregion
    }
}
