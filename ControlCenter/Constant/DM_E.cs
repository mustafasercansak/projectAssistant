using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    //------------------------------------------------ ------------------------------
    //-----< error code's >-----
    //------------------------------------------------ ------------------------------

    // If this bit is in the error code (dwError1), dwError2 contains the
    // System error code (GetLastError())
    //
    // if( pError->dwError1 & DM_E_SYS_ERROR )
    // {
    // // pError->dwError2 == System error code
    // }
    internal enum DM_E
    {       
        OK = 0x00000000, // No error
        CANCEL = 0x00000001, // User changed his mind
        FILE = 0x00000002, // File operation failed
        UPDATE = 0x00000003, // Project is being updated
        NO_RT_PRJ = 0x00000004, // No project in runtime mode
        NOT_SUPPORTED = 0x00000005, // requested service not available
        ALREADY_CONNECTED = 0x00000006, // Already connected to DM
        NOT_CONNECTED = 0x00000007, // No connection to DM
        INVALID_TAID = 0x00000008, // Invalid transaction ID
        INVALID_KEY = 0x00000009, // Variable not found
        INVALID_TYPE = 0x0000000A,
        MAX_LIMIT = 0x0000000B,
        MIN_LIMIT = 0x0000000C,
        MAX_RANGE = 0x0000000D,
        MIN_RANGE = 0x0000000E,
        ACCESS_FAULT = 0x0000000F,
        TIMEOUT = 0x00000010,
        ALREADY_EXIST = 0x00000011,
        PARAM = 0x00000012, // Invalid parameter
        INV_PRJ = 0x00000013, // Specified project not found/loaded
        UNKNOWN = 0x00000014,
        OOM = 0x00000015, // out of memory
        NOT_CREATED = 0x00000016, // Project could not be created
        MACHINE_NOT_FOUND = 0x00000017, // Machine not found
        NO_INFO_FOUND = 0x00000018, // no start info found
        INTERNAL = 0x00000019, // Internal processing error
        INVALID_LOCALE = 0x0000001A, // Invalid locale ID
        COMMUNICATION = 0x0000001B, // Incorrect locale ID
        DONT_EXIST = 0x0000001C,
        ALREADY_ACTIVATED = 0x0000001D,
        NO_OPEN_PROJECT = 0x0000001E,
        ALREADY_DEACTIVATED = 0x0000001F,
        NO_RIGHTS = 0x00000020, // wrong CreatorID passed
        NOT_DELETED = 0x00000021, // Object could not be deleted
        LICENSE = 0x00000022, // Software protection: no license
        LICENSE_LIMIT = 0x00000023, // Software protection: Limit reached/exceeded
        INVALID_OBJECTTYPE = 0x00000024,
        OP_REQUIERES_PRJEDITMODE = 0x00000025,
        INTERFACE = 0x00000026, // internal error accessing interfaces
        UNIT_NOT_FOUND = 0x00000027, // Unit not found
        CONNECTION_NOT_FOUND = 0x00000028, // Connection not found

        // errors for default server handling
        NODEFAULTSERVER = 0x00000101, // no DefaultServer configed (external given prefix "@default::" will be cutted)
        NOLOCALSERVER = 0x00000102, // no local server available
        NOSERVER = 0x00000103, // no DefaultServer configured and no local Server available
        NOMC = 0x00000104, // project is no Multiclient by DefaultServer handling (not used)
        NOMCDEFAULTSERVER = 0x00000105, // project is no Multiclient, but "@default::"-prefix was given (given prefix will be cutted)


        IS_WINCCFLEXIBLE_PROJECT = 0x00000201, // create/modify/delete not allowed if WinCC flexible project
        NO_WINCCFLEXIBLE_PROJECT = 0x00000202, // a WinCC flexible project is required

        SYS_ERROR = 0x10000000,
    }
}
