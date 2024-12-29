using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_SEND_DATA_STRUCT
    {
        [MarshalAs(UnmanagedType.Bool)]
        public bool fHighPriority;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.SERVICE_NAME + 1)]
        public string szService;
        [MarshalAs(UnmanagedType.U4)]
        public DM_SD dwTargetMachineFlags;
        public UInt32 dwTargetMachines;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = MAX_DM.OHIO_MACHINES + 1)]
        public DM_SD_TARGET_MACHINE[] dmTargetMachine;
        public UInt32 dwTargetApps;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = MAX_DM.OHIO_APPLICATIONS + 1)]
        public DM_SD_TARGET_APP[] dmTargetApp;
        public UInt32 dwDataSize;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)]
        public Byte[] byData;
    }
}
