using General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    /*     
    dwUserType is always 1.
    Values for dwUserCycle:
    12 = one-time 
    15 = hourly 
    16 = daily 
    17 = weekly
    18 = monthly 
    19 = yearly 
    stTime = point of time (if applicable, within the cycle). "stTime" must have complete default "GetSystemTime" or "GetLocalTime" as basis.
    Depending on "dwUserCycle", only write over the relevant parts to the modified. With the setting "Not weekly", the value "-1" is to be set for "stTime.wDayOfWeek".
    StTime.wDayOfWeek: 0=so, 1=mo... 6=sa, -1=not weekly 
    Sample: wDay=17 + wHour=12 + wMinute=30 if dwUserCycle=18 means every month on the 17th at 12:30 hours 
    */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    public class ActionAcyclicTrigger
    {
        public UInt32 UserType; 
        public UInt32 UserCycle; 
        public SystemTime systemTime;
    }
}
