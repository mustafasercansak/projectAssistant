using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlCenter;
using Scripts;

namespace Project_Assistant
{
    internal static class Program
    {
        static DataManager dataManager;
        static ApplicationManger applicationManger;
        public static Form1 MainForm { get; private set; }
        public static DataManager DataManager => dataManager;
        public static ApplicationManger ApplicationManger => applicationManger;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().RunAsync();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            applicationManger = new ApplicationManger("ProjectAssistant");
            dataManager = new DataManager("ProjectAssistant");
            MainForm = new Form1();
            dataManager.OnProjectOpened = () =>
            {
                MainForm.Exec((error) => applicationManger.Connect(error));
            };
            dataManager.OnProjectOpened = () =>
            {
                MainForm.Exec((error) => applicationManger.Disconnect(error));
            };
            Application.Run(MainForm);            
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
