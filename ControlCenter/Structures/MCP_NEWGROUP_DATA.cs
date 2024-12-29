using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class MCP_NEWGROUP_DATA
    {
        public UInt32 dwSize;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.GROUP_NAME + 1)]
        public string szGroupName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.CONNECTION_NAME + 1)]
        public string szConnection;
    }
}
