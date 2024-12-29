using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_VARGRP_DATA_EXSTR
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszVarGrpName;
        public UInt32 dwVarGrpNameCharCount;
        public UInt32 dwVarGrpID;
        public UInt32 dwCreatorID;
        public UInt16 dwVarNum;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszConnectionName;
        public UInt32 dwConnectionNameCharCount;
        public UInt32 dwConnectionID;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszUnitName;
        public UInt32 dwUnitNameCharCount;
        public UInt32 dwUnitID;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszDriverName;
        public UInt32 dwDriverNameCharCount;
        public UInt32 dwDriverID;
    }
}
