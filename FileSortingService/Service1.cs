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
        private Change ChangeObj { get; set; }
        public Service1()
        {
            InitializeComponent();
            ChangeObj = new Change();
        }
        public void onDebug()
        {
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
            ChangeObj.Start();
        }

        protected override void OnStop()
        {
            ChangeObj.Stop();
        }
    }
}
