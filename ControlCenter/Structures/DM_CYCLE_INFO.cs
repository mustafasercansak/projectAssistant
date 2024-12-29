using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_CYCLE_INFO
    {
        public UInt32 dwCycleTime;
        public UInt32 dwCycleIndex;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.CYCLE_NAME + 1)]
        public string szConnection;
    }
}
