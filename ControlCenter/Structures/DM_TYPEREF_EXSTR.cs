using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_TYPEREF_EXSTR
    {
        [MarshalAs(UnmanagedType.U4)]
        public DMVarTypes dwType;            /* See constants DM_TYPEREF_xxx */
        public UInt32 dwSize;            /* size of type in byte */
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszTypeName;      /* pointer to name of type */
        public UInt32 dwNameCharCount;   /* length of name of type in count of char's */
    }
}
