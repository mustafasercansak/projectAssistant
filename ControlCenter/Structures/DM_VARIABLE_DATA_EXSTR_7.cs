using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_VARIABLE_DATA_EXSTR_7
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszVariableName;         /* pointer to name of variable */
        public UInt32 dwVariableNameCharCount;  /* length of name of variable in count of char's */
        public UInt32 dwVariableID;             /* variable ID */
        public DM_TYPEREF_EXSTR dmTypeRef;      /* Type of variable-data */
        public DM_VARLIMIT dmVarLimit;          /* limits of variables */
        public object vdmStart;                 /* start value */
        public object vdmDefault;               /* default value */
        public UInt32 dwNotify;                 /* generate protokoll entry for ...*/
        public UInt32 dwFlags;                  /* Ersatzwert verwenden */
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszSpecific;             /* pointer to parameter string*/
        public UInt32 dwSpecificCharCount;      /* length of parameter string in count of char's */
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszGroup;                /* pointer to name of variable group */
        public UInt32 dwGroupCharCount;         /* length of name of variable proup in count of char's */
        public UInt32 dwGroupID;                /* variable group ID */
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszConnection;           /* pointer to name of connection */
        public UInt32 dwConnectionCharCount;    /* length of name of connection in count of char's */
        public UInt32 dwConnectionID;           /* connection ID */
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszChannel;              /* pointer to name of channel */
        public UInt32 dwChannelCharCount;       /* length of name of channel in count of char's */
        public UInt32 dwChannelID;              /* channel ID */
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszUnit;                 /* pointer to name of unit */
        public UInt32 dwUnitCharCount;          /* length of name of unit in count of char's */
        public UInt32 dwUnitID;                 /* unit ID */
        public MCP_VARIABLE_SCALES Scaling;     /* Skalierungsparameter */
        public UInt32 dwASDataSize;              /* Variablenlänge */
        public UInt32 dwOSDataSize;              /* Variablenlänge */
        public UInt32 dwVarProperty;             /* Variablen Eigenschaften (Interne / Externe Variable) */
        public UInt32 dwFormat;                  /* Formatanpassung */
        public UInt32 dwCreatorID;
        public UInt32 dwVarProperty2;
        public UInt32 dwVarWeighting;
        public UInt32 dwFlags2;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszPLCVariableName;
        public UInt32 dwPLCVariableNameCharCount;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszPLCBlockName;
        public UInt32 dwPLCBlockNameCharCount;
        public UInt32 dwPLCBlockNameID;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszComment;
        public UInt32 dwCommentCharCount;
    }
}
