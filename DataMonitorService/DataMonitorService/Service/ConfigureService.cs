using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace DataMonitorService.Service
{
    internal static class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<DataMonitorService>(service =>
                {
                    service.ConstructUsing(s => new DataMonitorService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                configure.SetServiceName("DataMonitorService");
                configure.SetDisplayName("DataMonitorService");
                configure.SetDescription("Data Monitor Service monitors a data source and updates a specified service host");
            });
        }
    }
}
