using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCenter
{
    public class DataManagerNotifyVariableEventArgs : EventArgs
    {
        // data members
        private readonly UInt32 transactionID;
        private readonly object[] variables;

        public DataManagerNotifyVariableEventArgs(uint transactionID, object[] variables)
        {
            this.transactionID = transactionID;
            this.variables = variables;
        }

        public uint TransactionID => transactionID;

        public object[] Variables => variables;
    }

    public delegate void DataManagerNotifyVariableEventHandler(object sender, DataManagerNotifyVariableEventArgs e);
}
