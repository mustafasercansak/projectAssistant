using ControlCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_VAR_UPDATE_STRUCT
    {
        public DM_TYPEREF dmTypeRef;
        public DM_VARKEY dmVarKey;
        [MarshalAs(UnmanagedType.Struct)]
        public object dmValue;
        [MarshalAs(UnmanagedType.U4)]
        public DMVarState dwState;
    }
}
