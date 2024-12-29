using General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Scripts
{
    internal class Helper
    {
        internal static ActionTrigger[] PointerToTrigger(IntPtr pArray, int length)
        {
            ActionTrigger[] structure = new ActionTrigger[length];
            IntPtr intPtr = new IntPtr(pArray.ToInt64());
            for (int i = 0; i < length; i++)
            {
                var trigger = Marshal.PtrToStructure<TRIGGER>(intPtr);
                structure[i] = new ActionTrigger()
                {
                    Name = trigger.psz_TriggerName,
                    TriggerType = (ActionTriggerType)trigger.dwTriggerType,
                    Cycle = (ActionTriggerCycle)trigger.dwCycle,
                    VarName = "",
                    Acyclic = null,
                };
                
                if (trigger.lpvTrigger != IntPtr.Zero && trigger.dwTriggerType == AP_TRIG.UNKNOWN)
                {
                    structure[i].Acyclic = Marshal.PtrToStructure<ActionAcyclicTrigger>(trigger.lpvTrigger);
                }
                if (trigger.lpTriggerVar != IntPtr.Zero && trigger.dwTriggerType == AP_TRIG.VAR)
                {
                    var varkey = Marshal.PtrToStructure<DM_VARKEY>(trigger.lpTriggerVar);
                    structure[i].VarName = varkey.szName;
                }

                intPtr = IntPtr.Add(intPtr, Marshal.SizeOf(trigger));
            }
            return structure;
        }
        internal static TRIGGER[] ToTrigger(List<string> tags)
        {
            TRIGGER[] structure = new TRIGGER[tags.Count];
            for (int i = 0; i < tags.Count; i++)
            {
                var key = new DM_VARKEY(tags[i]);
                IntPtr lpTriggerVar = Marshal.AllocHGlobal(Marshal.SizeOf(key));
                Marshal.StructureToPtr<DM_VARKEY>(key, lpTriggerVar,false);
                structure[i] = new TRIGGER()
                {
                    dwCycle = 0,
                    dwCycleType = 1,
                    dwTriggerType = AP_TRIG.VAR,
                    dwTriggerVersion = 2,
                    dwUserTriggerSize = 0,
                    lpTriggerVar = lpTriggerVar,
                    lpvTrigger = IntPtr.Zero,
                    psz_TriggerName = "Tag",                    
                };
            }
            return structure;
        }
    }
}
