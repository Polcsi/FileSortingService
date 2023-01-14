using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.ServiceProcess;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FileSortingService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
            try
            {
                new ServiceController(serviceInstaller1.ServiceName).Start();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"File Sorting Service:  {ex.Message} (FAILED TO START THE SERVICE)", EventLogEntryType.Error);
            }
        }
    }
}
