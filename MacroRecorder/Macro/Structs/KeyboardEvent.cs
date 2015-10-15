using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MacroRecorder.Macro.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyboardEvent
    {
        public uint vKeyCode;
        public uint scanCode;
        public uint Flags;
        public uint Time;
        public IntPtr dwExtraInfo;
    }
}
