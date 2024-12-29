using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    public enum DMNotifyClass
    {
        ERROR = 0x00000001, // notification code contains error identifier
        WARNING = 0x00000002, // notification code contains warning
        DATA = 0x00000003, // notification code contains type of data
    }
}
