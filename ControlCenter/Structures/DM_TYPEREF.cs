using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_TYPEREF
    {
        [MarshalAs(UnmanagedType.U4)]
        public DMVarTypes dwType;
        public UInt32 dwSize;   /* size of type in byte */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.TYPE_NAME + 1)]
        public string szTypeName; /* name of type */
    }
}
