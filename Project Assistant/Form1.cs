using Microsoft.Extensions.Logging.Console.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using ControlCenter;
using Scripts;
using System.Runtime.InteropServices;
using General;

namespace Project_Assistant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Program.DataManager.DataManagerNotify += DataManager_DataManagerNotify;
            Program.DataManager.DataManagerNotifyVariable += DataManager_DataManagerNotifyVariable;
            Program.ApplicationManger.ApplicationNotify += ApplicationManger_ApplicationNotify;
            error = new CMN_ERROR();
        }

        private void ApplicationManger_ApplicationNotify(object sender, Scripts.ApplicationNotifyEventArgs e)
        {
            if ((AP_NOTIFY)e.DwAPNotify == AP_NOTIFY.ERROR)
            {
                var a = Marshal.PtrToStructure<CMN_ERROR>(e.LpbyData);
                Console.Text += $"{(AP_NOTIFY)e.DwAPNotify} {a.szErrorText}\r\n";
            }
            else if((AP_NOTIFY)e.DwAPNotify == AP_NOTIFY.DATA)
            {
                Console.Text += $"{(AP_NOTIFY)e.DwAPNotify} {(AP_NOTIFY_CODE)e.DwAPNotifyCode}\r\n";
            }
        }

        private void DataManager_DataManagerNotifyVariable(object sender, DataManagerNotifyVariableEventArgs e)
        {
            Console.Text += $"Transaction ID: {e.TransactionID} Started\r\n";
            foreach (var item in e.Variables)
            {
                Console.Text += $"{item}\r\n";
            }
            Console.Text += $"Transaction ID: {e.TransactionID} is done\r\n";
        }

        private void DataManager_DataManagerNotify(object sender, DataManagerNotifyEventArgs e)
        {
            if ((DMNotifyClass)e.NotifyClass == DMNotifyClass.ERROR)
            {
                Console.Text += $"{(DMNotifyClass)e.NotifyClass} {(DMNotifyCodeWarning)e.NotifyCode}\r\n";
            }
            else if ((DMNotifyClass)e.NotifyClass == DMNotifyClass.WARNING)
            {
                Console.Text += $"{(DMNotifyClass)e.NotifyClass} {(DMNotifyCodeWarning)e.NotifyCode}\r\n";
            }
            else if ((DMNotifyClass)e.NotifyClass == DMNotifyClass.DATA)
            {
                Console.Text += $"{(DMNotifyClass)e.NotifyClass} {(DMNotifyCodeData)e.NotifyCode}  {e.ByData}\r\n";
            }
        }

        CMN_ERROR error;

        internal void Exec(Func<bool> func)
        {
            if (!func())
            {
                Console.Text += $"Connected = {error.szErrorText}\r\n";
            }            
        }

        internal void Exec(Func<CMN_ERROR, bool> func)
        {
            CMN_ERROR error = new CMN_ERROR();
            if (!func(error))
            {
                Console.Text += $"Connected = {error.szErrorText}\r\n";
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Exec((error) => Program.DataManager.Connect(error));
        }

        protected override void OnClosed(EventArgs e)
        {
            Program.DataManager.Disconnect(error);
            base.OnClosed(e);
        }
    }
}
