using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FileSortingService
{
    public partial class Service1 : ServiceBase
    {
        private Change Change { get; set; }
        public Service1()
        {
            InitializeComponent();
            Change = new Change();
        }
        public void onDebug()
        {
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
            Change.Start();
        }

        protected override void OnStop()
        {
            Change.Stop();
        }
    }
}
