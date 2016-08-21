using System;
using System.Timers;
using DataMonitorService.Models;

namespace DataMonitorService.Interfaces
{
    internal interface IDataMonitor
    {
        /// <summary>
        /// Configures the DataMonitor with specified DataMonitorConfiguration.
        /// </summary>
        /// <param name="dataMonitorConfiguration">The congifuration object.</param>
        void Configure(DataMonitorConfiguration dataMonitorConfiguration);

        /// <summary>
        /// Starts the monitoring.
        /// </summary>
        void StartMonitor();

        /// <summary>
        /// Stops the monitoring.
        /// </summary>
        void StopMonitor();
        
    }
}
