using System.Timers;
using DataMonitorService.Models;

namespace DataMonitorService.Interfaces
{
    internal interface IDataMonitor
    {
       void Configure(DataMonitorConfiguration fmc);

       void CheckAndUpate(object sender, ElapsedEventArgs e);
    }
}
