using MacroRecorder.Macro.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MacroRecorder.Macro.Events
{
    class MacroEvent_Mouse : IMacroEvent
    {
        public MouseEvent Event;
        public eMouseButton Button;
        INPUT[] InputList = new INPUT[1];
        int inputSize = 0;
        public MacroEvent_Mouse(MouseEvent _event, eMouseButton _button)
        {
            Event = _event;
            Button = _button;

            INPUT keyInput = new INPUT();
            keyInput.type = 0;
            MOUSEINPUT mInput = new MOUSEINPUT();

            eMouseCommand command = eMouseCommand.Move;
            if (Button == eMouseButton.LDOWN) command = eMouseCommand.LDown;
            if (Button == eMouseButton.LUP) command = eMouseCommand.LUp;
            if (Button == eMouseButton.RDOWN) command = eMouseCommand.RDown;
            if (Button == eMouseButton.RUP) command = eMouseCommand.RUp;
            if (Button == eMouseButton.MWheel) command = eMouseCommand.MWheel;
            if (Button == eMouseButton.MHWheel) command = eMouseCommand.HWHeel;

            mInput.dx = 0;
            mInput.dy = 0;
            mInput.mouseData = Event.mouseData;
            mInput.time = 0;
            mInput.dwExtraInfo = Event.extraInfo;
            mInput.dwFlags = (uint)command;

            keyInput.iUinion.mi = mInput;

            InputList[0] = keyInput;

            inputSize = Marshal.SizeOf(InputList[0]);
        }

        public void ExecuteEvent()
        {
            WinApi.SetCursorPos(Event.Location.X, Event.Location.Y);
            if(Button != eMouseButton.MOVE)
                WinApi.SendInput(1, InputList, inputSize);
        }


        public string GetEventString()
        {
            return string.Format("{0} {1}", Button, Event.Location);
        }
        public string GetEventType()
        {
            return "Mouse";
        }
    }
}
