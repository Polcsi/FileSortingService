using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FileSortingService
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if DEBUG
            Service1 serivce = new Service1();
            serivce.onDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            try
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new Service1()
                };
                ServiceBase.Run(ServicesToRun);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", "File Sorting Service: " + ex.ToString(), EventLogEntryType.Error);
            }
#endif
        }
    }
}
