using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMonitorService.Utilities
{
    internal static class Utility
    {
        internal static string GetAppSettingsFor(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
