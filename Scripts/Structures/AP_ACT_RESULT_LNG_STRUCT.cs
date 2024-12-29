using General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class AP_ACT_RESULT_LNG_STRUCT
    {
        public IntPtr ap_result;

        public AP_ACT_KEY_LNG apActKey;

        public CMN_ERROR error;

        public UInt32 dwreserved;
    }
}
