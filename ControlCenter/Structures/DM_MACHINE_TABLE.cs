using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_MACHINE_TABLE
    {
        public Int64 nNumMachines;
        public Int64 nLocalMachine;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = MAX_DM.OHIO_MACHINES)]
        public DM_SD_TARGET_MACHINE[] tm;
    }
}
