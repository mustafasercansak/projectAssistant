using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_ENUM_CONNECTION_DATA
    {
        public UInt32 dwSize;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.CONNECTION_NAME + 2)]
        public string szConnection;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.UNIT_NAME + 1)]
        public string szUnitName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH + 1)]
        public string szPath;      // Path of driver
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.CON_SPECIFIC + 1)]
        public string szSpecific;
        public UInt32 dwVarNum;
        public UInt32 dwCreatorID;
    }
}
