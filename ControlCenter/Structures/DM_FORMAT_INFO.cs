using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_FORMAT_INFO
    {
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwID;     /* Identification of the conversion routine */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.FORMAT_NAME + 1)]
        public string szName;   /* name of the conversion routine */
    }
}
