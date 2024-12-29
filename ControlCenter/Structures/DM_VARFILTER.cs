using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_VARFILTER
    {
        public DM_VARFILTER_TYPES dwFlags;
        public uint dwNumTypes;
        public uint[] pdwTypes;
        public string lpszGroup;
        public string lpszName;
        public string lpszConn;
    }
}
