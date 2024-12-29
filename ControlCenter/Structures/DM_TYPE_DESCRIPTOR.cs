using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_TYPE_DESCRIPTOR
    {
        [MarshalAs(UnmanagedType.Struct)]
        public DM_TYPEREF dmTypeRef;
        [MarshalAs(UnmanagedType.Struct)]
        public DM_TYPE_UNION dmType;
    }
}
