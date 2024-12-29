using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts
{
    public class ApplicationNotifyEventArgs : EventArgs
    {
        // data members
        private readonly UInt32 dwAPNotify;
        private readonly UInt32 dwAPNotifyCode;
        private readonly UInt32 dwError;
        private readonly IntPtr lpbyData;
        private readonly UInt32 dwItems;
        private readonly UInt32 dwOrderId;
        private readonly IntPtr lpvUser;

        public ApplicationNotifyEventArgs(UInt32 dwAPNotify, uint dwAPNotifyCode, uint dwError, IntPtr lpbyData, uint dwItems, uint dwOrderId, IntPtr lpvUser)
        {
            this.dwAPNotify = dwAPNotify;
            this.dwAPNotifyCode = dwAPNotifyCode;
            this.dwError = dwError;
            this.lpbyData = lpbyData;
            this.dwItems = dwItems;
            this.dwOrderId = dwOrderId;
            this.lpvUser = lpvUser;
        }

        public UInt32 DwAPNotify => dwAPNotify;

        public uint DwAPNotifyCode => dwAPNotifyCode;

        public uint DwError => dwError;

        public IntPtr LpbyData => lpbyData;

        public uint DwItems => dwItems;

        public uint DwOrderId => dwOrderId;

        public IntPtr LpvUser => lpvUser;
    }

    public delegate void ApplicationNotifyEventHandler(object sender, ApplicationNotifyEventArgs e);
}
