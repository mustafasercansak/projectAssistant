using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_SHIFT_INFO
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.SHIFT_NAME_LEN + 1)]
        public String szShiftName;
        public SYSTEMTIME stStart;
        public SYSTEMTIME stStop;
    }
}
