using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class VariantArray
    {
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 vt = (UInt16)(VarEnum.VT_ARRAY | VarEnum.VT_VARIANT);
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 wReserved1 = 0;
        public UInt16 wReserved2 = 0;
        public UInt16 wReserved3 = 0;
        [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)]
        public Object[] parray;
    }
}
