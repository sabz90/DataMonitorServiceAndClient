using System;
using DataMonitorService.Interfaces;
using DataMonitorService.Models;
using DataMonitorService.Models.Exceptions;
using DataMonitorService.Utilities;

namespace DataMonitorService.DataMonitor
{
    internal static class DataMonitorFactory
    {
        internal static IDataMonitor GetDataMonitor()
        {
            //Create configuration & verify
            var fmc = new DataMonitorConfiguration()
            {
                Source = Utility.GetAppSettingsFor("SourcePath"),
                Type = (SourceType)Enum.Parse(typeof(SourceType), Utility.GetAppSettingsFor("SourceType"))
            };
         
            //Check type of file   
            switch (fmc.Type)
            {
                case SourceType.CSV:
                    var csvFileMonitor = new CsvFileMonitor();
                    csvFileMonitor.Configure(fmc);
                    return csvFileMonitor;
                        
                case SourceType.TXT:
                case SourceType.XLS:
                case SourceType.XLSX:
                default:
                    var errMsg = string.Format("Input source of type '{0}' not supported yet!", fmc.Type);
                    Logger.LogError(errMsg);
                    throw new DataMonitorConfigurationException(errMsg);
            }
        }
    }
}
