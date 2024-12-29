using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandling
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    public class CMN_ERROR
    {
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dwError1;
        public UInt32 dwError2;
        public UInt32 dwError3;
        public UInt32 dwError4;
        public UInt32 dwError5;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public String szErrorText;
    }
}
