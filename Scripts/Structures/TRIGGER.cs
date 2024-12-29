using General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class TRIGGER
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string psz_TriggerName;

        public AP_TRIG dwTriggerType;

        public UInt32 dwCycleType;

        public UInt32 dwCycle;

        public UInt32 dwUserTriggerSize;

        public IntPtr lpvTrigger;
        public IntPtr lpTriggerVar;

        public UInt32 dwTriggerVersion;
        public TRIGGER()
        {

        }
        public TRIGGER(string TagName)
        {
            psz_TriggerName = TagName;
            dwTriggerType = AP_TRIG.VAR;
            dwCycleType = 1;
            dwCycle = 0;
            dwUserTriggerSize = 0;
            lpvTrigger = IntPtr.Zero;//Marshal.AllocHGlobal(Marshal.SizeOf<SystemTime>());
            var varKey = new DM_VARKEY(TagName);
            lpTriggerVar = Marshal.AllocHGlobal(Marshal.SizeOf(varKey));
            Marshal.StructureToPtr(varKey, lpTriggerVar, false);
        }
        public void Free()
        {
            Marshal.FreeHGlobal(lpvTrigger);
            Marshal.FreeHGlobal(lpTriggerVar);
        }
    }
}
