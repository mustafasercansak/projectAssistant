using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_CONNECTION_DATA_EXSTR
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszConnection;
        public UInt32 dwConnectionCharCount;
        public UInt32 dwConnectionID;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszUnitName;
        public UInt32 dwUnitNameCharCount;
        public UInt32 dwUnitID;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszCommon;
        public UInt32 dwCommonCharCount;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszSpecific;
        public UInt32 dwSpecificCharCount;
        public UInt32 dwVarNum;
        public UInt32 dwCreatorID;
    }
}
