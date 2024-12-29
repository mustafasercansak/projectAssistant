using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_ENUM_DRIVERUNIT_DATA
    {
        public UInt32 dwSize;
        public UInt32 dwCreatorID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.UNIT_NAME + 1)]
        public string szUnitName;      // Path of driver
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH + 1)]
        public string szPath;      // Path of driver
    }
}
