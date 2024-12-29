using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class MCP_NEWCONNECTION_DATA_EXSTR
    {
        [MarshalAs(UnmanagedType.U4)]
        public MCPNCon dwFlags;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszProjectFile;
        public UInt32 dwProjectFileCharCount;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszUnitName;
        public UInt32 dwUnitNameCharCount;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszConnection;
        public UInt32 dwConnectionCharCount;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszCommon;
        public UInt32 dwCommonCharCount;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszSpecific;
        public UInt32 dwSpecificCharCount;
        public UInt32 dwCreatorID;
    }
}
