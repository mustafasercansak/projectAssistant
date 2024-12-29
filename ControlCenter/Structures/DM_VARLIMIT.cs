using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_VARLIMIT
    {
        [MarshalAs(UnmanagedType.Struct)]
        public Object dmMaxRange;
        [MarshalAs(UnmanagedType.Struct)]
        public Object dmMinRange;
        [MarshalAs(UnmanagedType.Struct)]
        public Object dmMaxLimit;
        [MarshalAs(UnmanagedType.Struct)]
        public Object dmMinLimit;
    }
}
