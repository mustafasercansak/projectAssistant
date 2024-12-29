using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_VARIABLE_DATA
    {
        public DM_TYPEREF dmTypeRef;
        public DM_VARLIMIT dmVarLimit;
        public object dmStart;
        public object dmDefault;
        [MarshalAs(UnmanagedType.U4)]
        public DM_VARIABLE_NOTIFY dwNotify;
    }
}
