using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_BITFIELD_BIT_DESCRIPTOR
    {
        public UInt32 dwNumBits; /* number of occupied bits */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.MEMBER_NAME + 1)]
        public char szName; /* Name des Bits */
    }
}
