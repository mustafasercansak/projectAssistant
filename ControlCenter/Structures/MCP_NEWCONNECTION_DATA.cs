using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class MCP_NEWCONNECTION_DATA
    {
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH + 1)]
        public string szProjectFile;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.UNIT_NAME + 1)]
        public string szUnitName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.CONNECTION_NAME + 3)]
        public string szConnection;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.CON_COMMON + 1)]
        public string szCommon;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.CON_SPECIFIC + 1)]
        public string szSpecific;
    }
}
