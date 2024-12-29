using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    public enum DMNotifyCodeWarning
    {
        QUEUE_50_PERCENT = 0x00000001, // Warning class: Application queue is full
        QUEUE_60_PERCENT = 0x00000002, // ditto
        QUEUE_70_PERCENT = 0x00000003, // ditto
        QUEUE_80_PERCENT = 0x00000004, // ditto
        QUEUE_90_PERCENT = 0x00000005, // ditto
        QUEUE_OVERFLOW = 0x00000006, // too late...

        CYCLES_CHANGED = 0x00000010, // Class Warning, => Read cycles again
        MACHINES_CHANGED = 0x00000011, // Warning class, machine list
        PROJECT_OPENED = 0x00000012, // Class Warning, project is loading
        PROJECT_CLOSED = 0x00000013, // class Warning, project is being closed
        SYSTEM_LOCALE = 0x00000014, // Change language (resources).
        DATA_LOCALE = 0x00000015, // Change language (configuration data).
        PROJECT_RUNTIME = 0x00000016, // Project activated in runtime mode
        PROJECT_EDIT = 0x00000017, // Runtime mode disabled for project
        HOTKEY_CHANGE = 0x00000018, /* The hotkeys have changed */
        URSEL = 0x00000019,
        RT_LIC = 0x00000020,
        CS_LIC = 0x00000021,

        BODO = 0x00000050,
        BEGIN_PROJECT_EDIT = 0x00000051,

    }
}
