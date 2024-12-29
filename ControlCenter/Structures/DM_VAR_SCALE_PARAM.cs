using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_VAR_SCALE_PARAM
    {
        public double dValue;         /* Wert des Parameters */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DM.SCALE_PARAM_NAME + 1)]
        public string szName;    /* Parametername */
    }
}
