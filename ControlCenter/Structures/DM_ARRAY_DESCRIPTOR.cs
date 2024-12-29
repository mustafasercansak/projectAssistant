using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_ARRAY_DESCRIPTOR
    {
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwNumElements; /* number of array elements */
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwASElemSize; /* element size AS */
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwASElemOffset; /* offset within an AS element */
        [MarshalAs(UnmanagedType.Struct)]
        public DM_FORMAT_INFO dmFormat; /* number format information */
        [MarshalAs(UnmanagedType.Struct)]
        public DM_SCALE_INFO dmScale; /* scaling information */
    }
}
