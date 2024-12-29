using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_ENUM_GROUP_DATA
    {
        public UInt32 dwSize;
        public UInt32 dwCreatorID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.GROUP_NAME + 1)]
        public string szGroupName;      // // Name of Group
                                        //
                                        // The following fields are containing valid data if the tag-group
                                        // contains external tags.
                                        // The fields are containing '\0' if the group contains internal tags
                                        //
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.CONNECTION_NAME + 1)]
        public string szConnectionName;      // Path of driver
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.UNIT_NAME + 1)]
        public string szUnitName;      // Path of driver
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STDLIB._MAX_PATH + 1)]
        public string szDriverName;      // Path of driver
    }
}
