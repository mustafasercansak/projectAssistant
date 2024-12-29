using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class MCP_CHNCONVERSION_EXSTR
    {
        [MarshalAs(UnmanagedType.Bool)]
        public bool bUsesChannelConversion;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszUnit;
        public UInt32 dwUnitCharCount;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszChnName;
        public UInt32 dwChnNameCharCount;
    }
}
