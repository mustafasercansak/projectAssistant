using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    /*
    * Length constants
    */
    internal class MAX_DM
    {
        public const int OHIO_MACHINES = 64, /* maximum number of OHIO computers in a project */
        OHIO_APPLICATIONS = 32, /* maximum number of local client applications */
        UPDATE_CYCLES = 15, /* maximum number of update cycles */
        SYSTEM_CYCLES = 10, /* of which 10 are system cycles */
        USER_CYCLES = 5, /* + 5 users */

        VAR_NAME = 128, /* maximum length of a variable name */
        TYPE_NAME = 128, /* maximum length of a data type name */
        GROUP_NAME = 64, /* maximum length of a variable group name */
        CYCLE_NAME = 64, /* maximum length of a cycle time text */
        FORMAT_NAME = 64, /* maximum length of a format specification */
        SCALE_NAME = 64, /* maximum length of a scaling rule */
        SCALE_PARAM_NAME = 64, /* maximum length of a scaling parameter description */
        MEMBER_NAME = 128, /* maximum length for members of composite types */
        INFOTEXT_LEN = 255, /* maximum length of an info text */
        SHIFT_NAME_LEN = 32, /* maximum length of a shift name */
        SHIFTS = 16, /* maximum number of shifts per day */
        SHIFT_HOLYDAYS = 30, /* maximum number of holidays in the shift schedule */
        SHIFT_HOLYNAME = 64, /* maximum length of a holiday name */
        SERVICE_NAME = 32, /* maximum length of a service name */
        APP_NAME = 32, /* maximum length of a log. application name */
        DSN_NAME = 32, /* maximum length data source name of the database */
        UNIT_NAME = 65, /* maximum length of a unit */
        CONNECTION_NAME = 32, /* maximum length of a connection */
        VAR_SPECIFIC = 256, /* maximum length of the specific part of a variable in the GAPI */
        CON_SPECIFIC = 128, /* maximum length of specific part of connection in GAPI */
        CON_COMMON = 128, /* maximum length of specific part of a connection in GAPI */
        VARTYPE_TEXT_LEN = 255, /* maximum length of a text variable */
        COMMENT_NAME = 100; /* maximum length of a comment */
    }
}
