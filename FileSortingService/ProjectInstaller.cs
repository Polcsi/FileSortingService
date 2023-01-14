using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.ServiceProcess;
using System.IO;
using System.Linq;

namespace FileSortingService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        private Settings Settings { get; set; }
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
                EventLog.WriteEntry("Application", $"File Sorting Service:  {ex.Message}", EventLogEntryType.Error);
            }
        }

        private void serviceInstaller1_AfterUninstall(object sender, InstallEventArgs e)
        {
            try
            {
                // Only delete directories when they are empty 
                if(Directory.Exists(Settings.selectedPath) && IsDirectoryEmpty(Settings.selectedPath)) 
                {
                    Directory.Delete(Settings.selectedPath, true);
                }
                if(Directory.Exists(Settings.defaultPath) && IsDirectoryEmpty(Settings.defaultPath))
                {
                    Directory.Delete(Settings.defaultPath, true);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"File Sorting Service: {ex.Message}", EventLogEntryType.Error);
            }
        }

        private void serviceInstaller1_BeforeUninstall(object sender, InstallEventArgs e)
        {
            try
            {
                Settings = Change.LoadJson(AppDomain.CurrentDomain.BaseDirectory + "\\" + "settings.json");
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", $"File Sorting Service: {ex.Message}", EventLogEntryType.Error);
            }
        }
        public static bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
    }
}
