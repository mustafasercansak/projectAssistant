using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    public enum APError
    {
        NO_ERROR  =1, // No error occurred
        ALREADY_CONNECTED = 2, // Application is already connected to the action controller
        NO_CONNECTION = 3, // Application cannot connect to the action controller
                                                   // record, tape.
        ERROR_IPC_SEND = 4, // When sending the telegram for action control
                                                   // an error occurred.
        FAILURE_UNKNOWN = 5, // Unspecified error
        FAILURE_PARAM = 6, // Incorrect parameter supply
        NO_ACT_PROGRAM = 7, // Could not start action control
        TIMEOUT = 8, // Timeout
        ACT_QUIT = 9, // Action control has ended
        INSTALL_SERV_ERROR = 10, // Service channel could not be installed
        ENDACT_UNKNOWN_ORDER = 11, // An unknown order number was used for the EndAct
        ACTION_FAILED = 12, // An action could not be executed correctly.
                                                   // The return results are invalid.
        FAILURE_IN_SERVER = 13, // An error is reported by the server.
        TO_MANY_CLIENTS = 14, // The maximum number of connections has been reached.
                                                   // No new connections possible.
        TRANSACTID_UNKNOWN = 15, // Transaction ID is not valid. Error occurs when calling
                                                   // by AP_EndAct when attempting to end a transaction
                                                   // which was not previously registered.
        NO_MEMORY = 16, // There is not enough memory left for this operation
                                                   // available
        TRANSACT_ERROR = 17, // An error occurred within the transaction
                                                   // Action related error in dwerror of AP_ACT_KEY
        RESULT_TRANS_ERROR = 18, // There was an error with the results
        RESULT_START_ERROR = 19, // There was an error with the results

        NO_UPDATE_WRONG_FORMAT = 50, // There is no update option for the data format
                                     // More about this source text
                                     // Source text required for additional translation information
                                     // Send feedback
                                     // Side panels

        //////////////////////////////////////////////// ////////////////////////////
        // Error values ​​from dwerror in AP_ACT_KEY
        //////////////////////////////////////////////// ////////////////////////////

        ERR_NO_P_CODE = 201, // Action does not contain interpreter code.
        WRONG_FORMAT = 202, // Action has wrong data format.
        NO_VALID_FUNCTION_VALUE = 203, // Function return value cannot be in the
            // be converted to VARIANT data type.

        CISS_ERR_EXIT_OVERFLOW = 1001, // There was a stack overflow in the action interpreter during the
            // Execution occurred. Further execution of the action is aborted.
        CISS_ERR_EXIT_DIVIDE0 = 1002, // A division by 0 occurred during the execution of an action.
            // Action is aborted.
        CISS_ERR_EXIT_UNRESOLVED = 1003, // Within the action, during execution, a not
            // existing symbol referenced.
        CISS_ERR_EXIT_GPF = 1004, // Within the action was not during execution
            // Defined memory accessed.
        CISS_ERR_EXIT_BREAKPOINT = 1005, // The action interpreter hit a breakpoint.
        CISS_ERR_EXIT_STEP = 1006, // The action interpreter was expanded in the debugger by one
                                   // Processing step continued.

        CISS_ERR_CREATE_PCH_FROM_PCH = 8001, // A precompiled header file cannot be created from a precompiled
                // Generate header file.
        CISS_ERR_MODULE_IN_USE = 8002, // The action cannot be accessed.
                // The module is currently in use.
        CISS_ERR_INVALID_PROGRAM = 8003, // The program is invalid.
        CISS_ERR_INVALID_MODULE = 8004, // The action is invalid.
        CISS_ERR_CANNOT_CREATE_FILE = 8005, // Action control could not create file.
        CISS_ERR_CANNOT_NO_MEMORY = 8006, // The action interpreter ran out of memory.
        CISS_ERR_INVALID_FILE_FORMAT = 8007, // File format is invalid for action control.
        CISS_ERR_CANNOT_OPEN_FILE = 8008, // The action control could not open the file.
        CISS_ERR_PROGRAM_IS_LOCKED = 8009, // Program is currently locked by action control.
        CISS_ERR_MODULE_ALREADY_INSERTED = 8010, // Action has already been assigned to action control for processing.
        CISS_ERR_CONFLICT_WITH_OTHER = 8011, // The action has a conflict with another action.
        CISS_ERR_MODULE_NOT_FOUND = 8013, // Action not found by action control.
        CISS_ERR_FUNCTION_NOT_FOUND = 8014, // Function not found by action control.
        CISS_ERR_INVALID_LINE = 8015, // The specified line information is invalid.
        CISS_ERR_INVALID_SCOPE = 8016 ,// Specified symbol is out of scope.
        CISS_ERR_BUFFER_TOO_SMALL = 8017, // The transferred memory is too small for the action interpreter.
        CISS_ERR_INVALID_TYPE = 8018, // The specified type is unknown to the action interpreter.
        CISS_ERR_SYMBOL_NOT_FOUND = 8019, // The specified symbol was not found.
    }
}
