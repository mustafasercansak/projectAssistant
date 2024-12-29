using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    public enum DM_SDMODE
    {
        SYSTEM = 0x00000000,   /* Shutdown Windows without Reboot */
        WINCC = 0x00000001,   /* Terminate WinCC */
        LOGOFF = 0x00000002,   /* Terminate WinCC and Log off */
        REBOOT = 0x00000003,   /* Terminate WinCC and reboot Windows */
        POWEROFF = 0x00000004,   /* Shutdown Windows and power off RQ287443 */		
        FORCE_POWEROFF = 0x00000005,	/*Shutdown windows and power off by force - RQ AP01291487*/

    }
}
