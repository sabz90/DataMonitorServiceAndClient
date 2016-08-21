using System;
using System.Text;
using System.IO;

namespace DataMonitorService.Utilities
{
    internal static class Logger
    {
        private static readonly string ErrorFilePath = Utility.GetAppSettingsFor("errorLogFilePath");
        private static readonly string OperationsFilePath = Utility.GetAppSettingsFor("operationsLogFilePath");
        private static readonly string WarningFilePath = Utility.GetAppSettingsFor("warningLogFilePath");

        //Locks are needed here for thread safety.
        private static readonly object ErrLock = new object();
        private static readonly object OpLock = new object();
        private static readonly object WrnLock = new object();

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="errorMsg">The error MSG.</param>
        public static void LogError(string errorMsg)
        {
            lock (ErrLock)
            {
                var sb = new StringBuilder();
                sb.Append(DateTime.Now);
                sb.Append(": " + errorMsg);
                sb.AppendLine();
                File.AppendAllText(ErrorFilePath, sb.ToString());
            }
        }

        /// <summary>
        /// Logs the operations.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public static void LogOperations(string msg)
        {
            lock (OpLock)
            {
                var sb = new StringBuilder();
                sb.Append(DateTime.Now);
                sb.Append(": " + msg);
                sb.AppendLine();
                File.AppendAllText(OperationsFilePath, sb.ToString());
            }
        }

        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="wrnMsg">The WRN MSG.</param>
        public static void LogWarning(string wrnMsg)
        {
            lock (WrnLock)
            {
                var sb = new StringBuilder();
                sb.Append(DateTime.Now);
                sb.Append(": " + wrnMsg);
                sb.AppendLine();
                File.AppendAllText(WarningFilePath, sb.ToString());
            }
        }
    }
}
