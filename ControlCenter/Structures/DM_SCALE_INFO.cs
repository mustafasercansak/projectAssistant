using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_SCALE_INFO
    {
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwID; /* Identification of the normalization routine */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.SCALE_NAME + 1)]
        public string szName; /* name of the normalization routine */
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwNumParams; /* number of required parameters */
    }
}
