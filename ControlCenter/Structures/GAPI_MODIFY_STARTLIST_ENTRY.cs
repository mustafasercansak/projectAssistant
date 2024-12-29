using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    internal class GAPI_MODIFY_STARTLIST_ENTRY
    {
        public uint dwIndex;
        public int OnOff;		// 0 = off, 1 = on
        public string szComment;
    }
}
