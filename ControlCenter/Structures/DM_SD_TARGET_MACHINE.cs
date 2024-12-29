using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_SD_TARGET_MACHINE
    {
        [MarshalAs(UnmanagedType.Bool)]
        public bool fServer;
        [MarshalAs(UnmanagedType.Bool)]
        public bool fLocal;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.UNIT_NAME + 1)]
        public string szMachineName;
    }
}
