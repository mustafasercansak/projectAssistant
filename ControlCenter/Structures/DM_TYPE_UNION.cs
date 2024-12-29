using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_TYPE_UNION
    {
        [MarshalAs(UnmanagedType.Struct)]
        public DM_BITFIELD_DESCRIPTOR dmBitField;
        [MarshalAs(UnmanagedType.Struct)]
        public DM_ARRAY_DESCRIPTOR dmArray;
        [MarshalAs(UnmanagedType.Struct)]
        public DM_STRUCT_DESCRIPTOR dmStruct;
    }
}
