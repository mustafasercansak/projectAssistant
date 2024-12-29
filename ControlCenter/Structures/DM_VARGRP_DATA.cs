using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_VARGRP_DATA
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.VAR_NAME + 1)]
        public string szName;
        public UInt32 dwCreatorID;
        public UInt16 dwVarNum;
        public IntPtr lpvUserData;
    }
}
