using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    public enum AP_NOTIFY_CODE
    {
        TRANSACT = 1, // Confirmation of an AP_TransAct call
        START = 2, // Confirmation of an AP_Start call
        RESULT = 3, // Result of an action
        ENUMPOOL = 4,
        LOADPOOL = 5,
        DISCONNECT = 6,
        ENDACT = 7, // Confirmation of an AP_EndAct call
        ACTIVE = 8, // Confirmation of an AP_Active call
        INACTIVE = 9, // Confirmation of an AP_Inactive call

        ERROR_SERVER_QUITT = 10, // Notification that the action control
                                 // finished.
        TRANSRESULT = 11, // Notify for an incorrect result call of an APTransAct
        STARTRESULT = 12, // Notify for an erroneous result call of an APStart

    }
}
