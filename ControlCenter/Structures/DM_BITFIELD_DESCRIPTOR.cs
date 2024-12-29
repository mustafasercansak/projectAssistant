using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_BITFIELD_DESCRIPTOR
    {
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwNumBits; /* number of occupied bits */
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwBits; /* Occupied bit positions == 1 */
    }
}
