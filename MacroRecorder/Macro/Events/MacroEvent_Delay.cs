using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MacroRecorder.Macro.Events
{
    public class MacroEvent_Delay : IMacroEvent
    {
        public int DelayMS = 0;
        public MacroEvent_Delay(int ms)
        {
            DelayMS = ms;
        }
        public void ExecuteEvent()
        {
            Thread.Sleep(DelayMS);
        }
        public string GetEventString()
        {
            return string.Format("{0}ms", DelayMS);
        }
        public string GetEventType()
        {
            return "Delay";
        }
    }
}
