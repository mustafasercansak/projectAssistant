using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    internal class DM_STRUCT_MEMBER_DESCRIPTOR
    {
        [MarshalAs(UnmanagedType.LPArray, SizeConst = MAX_DM.MEMBER_NAME)]
        public byte[] szName;     /* Name des Members */
        public UInt32 dwOSOffset;     /* Offset im Wertepuffer der Struktur */
        public UInt32 dwASOffset;     /* Offset im AS Puffer */
        public DM_FORMAT_INFO dmFormat;       /* Zahlenformatinformation */
        public DM_SCALE_INFO dmScale;        /* Skalierungsinformation */
    }
}
