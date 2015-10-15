using MacroRecorder.Macro.Structs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacroRecorder.Macro.Events
{
    class MacroEvent_Keyboard : IMacroEvent
    {
        eKeyboardEvent EventType;
        KeyboardEvent Event;
        public MacroEvent_Keyboard(eKeyboardEvent _eType, KeyboardEvent _event)
        {
            EventType = _eType;
            Event = _event;
        }
        public void ExecuteEvent()
        {
            uint keyState = Convert.ToUInt32(EventType == eKeyboardEvent.KeyDown ? 0 : 0x2);
            INPUT[] InputList = new INPUT[1];

            INPUT keyInput = new INPUT();
            keyInput.type = 1;
            KEYBDINPUT kbInput = new KEYBDINPUT();
            kbInput.wVk = Convert.ToUInt16(Event.vKeyCode);
            kbInput.wScan = Convert.ToUInt16(Event.scanCode);
            kbInput.dwFlags = keyState;
            kbInput.time = 0;
            kbInput.dwExtraInfo = Event.dwExtraInfo;

            keyInput.iUinion.ki = kbInput;

            InputList[0] = keyInput;

            WinApi.SendInput(1, InputList, Marshal.SizeOf(InputList[0]));
        }

        public string GetEventString()
        {
            return string.Format("{1} {0}", EventType == eKeyboardEvent.KeyDown ? "Press" : "Release", ((Keys)Event.vKeyCode).ToString());
        }

        public string GetEventType()
        {
            return "Keyboard";
        }
    }
}
