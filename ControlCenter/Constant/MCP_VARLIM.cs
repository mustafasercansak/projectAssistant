using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    public enum MCPVarLim
    {
        HAS_MIN_LIMIT = 0x00000008, // Variable has fixed lower limit
        HAS_MAX_LIMIT = 0x00000010, // Variable has fixed upper limit
        HAS_DEFAULT_VALUE = 0x00000020, // Variable has default value
        HAS_STARTUP_VALUE = 0x00000040, // Variable has initialization value
        USE_DEFAULT_ON_STARTUP = 0x00000080, // Enter default value at system start
        USE_DEFAULT_ON_MAX = 0x00000100, // Enter a replacement value when the upper limit is exceeded
        USE_DEFAULT_ON_MIN = 0x00000200, // Enter substitute value when falling below the lower limit
        USE_DEFAULT_ON_COMM_ERROR = 0x00000400, // Default value on connection error
    }
}
