using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_TYPE_DESCRIPTOR_EXSTR
    {
        public DM_TYPEREF_EXSTR dmTypeRef;
        public DM_TYPE_UNION dmType;
    }
}
