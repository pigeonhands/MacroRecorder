using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroRecorder.Macro
{
    public interface IMacroEvent
    {
        void ExecuteEvent();
        string GetEventType();
        string GetEventString();
    }

    public enum eKeyboardEvent
    {
        KeyDown = 0x100,
        KeyUp = 0x101,
        SysKeyDown = 0x104,
        SysKeyUp = 0x105
    }

    public enum eMouseEvent
    {
        MOVE = 0x200,
        LDOWN = 0x201,
        LUP = 0x202,
        RDOWN = 0x204,
        RUP = 0x205,
        MWheel = 0x20A,
        MHWheel = 0x20E
    }
}
