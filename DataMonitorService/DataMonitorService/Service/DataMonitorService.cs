using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using DataMonitorService.DataMonitor;
using DataMonitorService.Utilities;

namespace DataMonitorService.Service
{
    class DataMonitorService
    {
        private Timer _timer;
        public DataMonitorService()
        {
            SetupService();
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
            
        private void SetupService()
        {
            //setup the timer with configured values
            SetupTimer();

            //Get the file monitor depending on configuration
            var dataMonitor = DataMonitorFactory.GetDataMonitor();

            //Check for updates to the file every interval
            _timer.Elapsed += new ElapsedEventHandler(dataMonitor.CheckAndUpate);
        }

        private void SetupTimer()
        {
            _timer = new Timer(double.Parse(Utility.GetAppSettingsFor("TimerIntervalMilliseconds")))
            {
                AutoReset = true
            };
        }
       
    }
}
