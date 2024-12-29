using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    public enum VARFLAGS2
    {
        NEWINSTANCE_TYPE		= 0x00000001,
        OPCWRITEPROTECT		= 0x00000002,
        OPCREADPROTECT		= 0x00000004,
        GMPRELEVANT			= 0x00000008,
        ESIG       			= 0x00000010,
        CLOUDENABLED 			= 0x00000020,
    }
}
