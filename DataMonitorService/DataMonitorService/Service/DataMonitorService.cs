using System;
using DataMonitorService.DataMonitor;
using DataMonitorService.Interfaces;
using DataMonitorService.Utilities;

namespace DataMonitorService.Service
{
    class DataMonitorService
    {
        /// <summary>
        /// The data monitor
        /// </summary>
        private readonly IDataMonitor _dataMonitor;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataMonitorService"/> class depending on app settings
        /// </summary>
        public DataMonitorService()
        {
            try
            {
                _dataMonitor = DataMonitorFactory.GetDataMonitor();
                Logger.LogOperations("Initialized DataMonitor Successfully");

            }
            catch (Exception ex)
            {
                Logger.LogError(string.Format("Fatal Error occured when attempting to initialize data monitor service. \nMessage: {0}\nDetails:{1}", ex.Message, ex.StackTrace));
            }
        }

        /// <summary>
        /// Starts this Data Monitor.
        /// </summary>
        public void Start()
        {
            try
            {
                Logger.LogOperations("#### DATA MONITOR STARTING ####");
                _dataMonitor.StartMonitor();
            }
            catch (Exception ex)
            {
                Logger.LogError(string.Format("Fatal Error occured when attempting to start data monitor service. \nMessage: {0}\nDetails:{1}", ex.Message, ex.StackTrace));
            }
        }

        /// <summary>
        /// Stops the Data Monitor.
        /// </summary>
        public void Stop()
        {
            try
            {
                Logger.LogOperations("#### DATA MONITOR STOPPING ####");
                _dataMonitor.StopMonitor();
            }
            catch (Exception ex)
            {
                Logger.LogError(string.Format("Fatal Error occured when attempting to STOP data monitor service. \nMessage: {0}\nDetails:{1}", ex.Message, ex.StackTrace));
            }
        }
    }
}
