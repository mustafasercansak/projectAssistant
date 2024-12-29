using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    public enum DMNotifyCodeError
    {
        SHUTDOWN = 0x00000001, // Class Error : DM is shutting down
        PROCESSNET_ERROR = 0x00000002, // Class Error : Error on process bus
        SYSNET_ERROR = 0x00000003, // Class Error : Error on system bus
    }
}
