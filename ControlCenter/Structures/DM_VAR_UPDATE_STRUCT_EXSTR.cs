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
    internal class DM_VAR_UPDATE_STRUCT_EXSTR
    {
        [MarshalAs(UnmanagedType.Struct)]
        public DM_TYPEREF_EXSTR dmTypeRef;
        [MarshalAs(UnmanagedType.Struct)]
        public Object vdmVarKey;
        [MarshalAs(UnmanagedType.Struct)]
        public Object vCookie;
        [MarshalAs(UnmanagedType.Struct)]
        public Object vdmValue;
        [MarshalAs(UnmanagedType.U4)]
        public DMVarState dwState;
        [MarshalAs(UnmanagedType.U4)]
        public DMVarState dwQualityCode;
    }
}
