using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; //
using System.Threading.Tasks;

namespace ControlCenter
{
    public enum DMVarState
    {
        NONE=0,
        NOT_ESTABLISHED = 0x0001, // Connection to partner not established
        HANDSHAKE_ERROR = 0x0002, // Protocol error
        HARDWARE_ERROR = 0x0004, // Network board is on fire
        MAX_LIMIT = 0x0008, // configured upper limit exceeded
        MIN_LIMIT = 0x0010, // Below configured lower limit
        MAX_RANGE = 0x0020, // Format limit exceeded
        MIN_RANGE = 0x0040, // Below format limit
        CONVERSION_ERROR = 0x0080, // Display conversion error
        STARTUP_VALUE = 0x0100, // Initialization value of the variable
        DEFAULT_VALUE = 0x0200, // Substitute value of the variable
        ADDRESS_ERROR = 0x0400, // Addressing error in channel
        INVALID_KEY = 0x0800, // Variable not found / not available
        ACCESS_FAULT = 0x1000, // Access to variable not allowed
        TIMEOUT = 0x2000, // Timeout / no feedback from the channel
        SERVERDOWN = 0x4000, // Server is down
    }
}
