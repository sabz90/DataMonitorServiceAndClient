using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMonitorService.Models.Exceptions;

namespace DataMonitorService.Utilities
{
    internal static class Utility
    {
        /// <summary>
        /// Gets the application settings for the given key
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        internal static string GetAppSettingsFor(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (ConfigurationErrorsException ex)
            {
                Logger.LogError("Error occured when trying to read configuration for " + key + "\nDetails: " + ex.StackTrace);
                throw new DataMonitorConfigurationException("Error occured when trying to read configuration for " + key,ex);
            }
        }
    }
}
