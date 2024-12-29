using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    public class DataManagerNotifyEventArgs : EventArgs
    {
        // data members
        private readonly UInt32 dwNotifyClass;
        private readonly UInt32 dwNotifyCode;
        private readonly IntPtr lpbyData;
        private readonly UInt32 dwItems;
        private readonly IntPtr lpvUser;

        public DataManagerNotifyEventArgs(UInt32 dwNotifyClass,
                         UInt32 dwNotifyCode,
                         IntPtr lpbyData,
                         UInt32 dwItems,
                         IntPtr lpvUser)
        {
            this.dwNotifyClass = dwNotifyClass;
            this.dwNotifyCode = dwNotifyCode;
            this.lpbyData = IntPtr.Zero;
            this.lpvUser = lpvUser;
            this.dwItems = dwItems;
            if (0 != dwItems)
            {
                this.lpbyData = lpbyData;
            }
        }

        public uint NotifyClass => dwNotifyClass;

        public uint NotifyCode => dwNotifyCode;

        public IntPtr ByData => lpbyData;

        public uint Items => dwItems;

        public IntPtr User => lpvUser;
    }

    public delegate void DataManagerNotifyEventHandler(object sender, DataManagerNotifyEventArgs e);
}
