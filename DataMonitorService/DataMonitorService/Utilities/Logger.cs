using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace DataMonitorService.Utilities
{
    internal static class Logger
    {
        private static readonly string ErrorFilePath = Utility.GetAppSettingsFor("errorLogFilePath");
        private static readonly string OperationsFilePath = Utility.GetAppSettingsFor("operationsLogFilePath");
        private static readonly string WarningFilePath = Utility.GetAppSettingsFor("warningLogFilePath");

        public static void LogError(string errorMsg)
        {
            var sb = new StringBuilder();
            sb.Append(DateTime.Now);
            sb.Append(": " + errorMsg);
            sb.AppendLine();
            
            File.AppendAllText(ErrorFilePath, sb.ToString());
        }

        public static void LogOperations(string msg)
        {
            var sb = new StringBuilder();
            sb.Append(DateTime.Now);
            sb.Append(": " + msg);
            sb.AppendLine();

            File.AppendAllText(OperationsFilePath, sb.ToString());
        }

        public static void LogWarning(string wrnMsg)
        {
            var sb = new StringBuilder();
            sb.Append(DateTime.Now);
            sb.Append(": " + wrnMsg);
            sb.AppendLine();

            File.AppendAllText(WarningFilePath, sb.ToString());
        }
    }
}
