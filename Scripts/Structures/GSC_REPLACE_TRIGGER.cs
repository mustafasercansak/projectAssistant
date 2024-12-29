using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class GSC_REPLACE_TRIGGER
    {
        public IntPtr pAction;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszTriggerName;
        public UInt32 dwGSCTriggerType;
        public IntPtr ptGSCDateTime;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszOldTriggerName;
    }
}
