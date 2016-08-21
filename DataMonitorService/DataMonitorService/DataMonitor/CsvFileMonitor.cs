using System;
using System.Data;
using System.IO;
using DataMonitorService.Interfaces;
using DataMonitorService.Models;
using DataMonitorService.Models.Exceptions;
using DataMonitorService.Utilities;
using System.Security.Permissions;
using CsvHelper;

namespace DataMonitorService.DataMonitor
{
    internal class CsvFileMonitor: IDataMonitor
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private DataMonitorConfiguration _config;
        
        /// <summary>
        /// The watcher for the input file
        /// </summary>
        private FileSystemWatcher _watcher;

        /// <summary>
        /// The status lock. Required for thread safety when updating the isUpdateRequired variable.
        /// </summary>
        private readonly object _statusLock = new object();

        /// <summary>
        /// The isUpdateRequired variable that tells if the input data should be refreshed
        /// </summary>
        private bool _isUpdateRequired = true;

        /// <summary>
        /// The retry count when the read/update operation fails.
        /// </summary>
        private int retryCount = 0;
        
        /// <summary>
        /// Configures the data monitor and also validates the configuration
        /// </summary>
        /// <param name="dataMonitorConfiguration"></param>
        public void Configure(DataMonitorConfiguration dataMonitorConfiguration)
        {
            Logger.LogOperations("Received Configuration. Validating...");

            ValidateConfiguration(dataMonitorConfiguration);
            _config = dataMonitorConfiguration;

            Logger.LogOperations("Validated Configuration.");
        }

        /// <summary>
        /// Starts monitoring the file for changes and updates the specified service host if necessary.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void StartMonitor()
        {
            ConfigureWatch();
            while (true)
            {
                if (_isUpdateRequired)
                {
                    Logger.LogOperations("START Update:");

                    var success = ReadDataAndUpdateServiceHost();
                    if (success)
                    {
                        UpdateStatusVariable(false);
                    }
                    else if (retryCount >= _config.MaxRetryCount)
                    {
                        UpdateStatusVariable(false);
                        Logger.LogWarning(string.Format("Update task re-attempted {0} times (MAX). Skipping and waiting for next update.", retryCount));
                    }

                    Logger.LogOperations("END Update!");
                }
            }
        }

        /// <summary>
        /// Stops the monitor.
        /// </summary>
        public void StopMonitor()
        {
            _watcher.Changed -= FileModifiedHandler;
        }

        /// <summary>
        /// Configures the watch for the csv file.
        /// </summary>
        private void ConfigureWatch()
        {
            Logger.LogOperations("Configuring Watch....");

            // Create a new FileSystemWatcher to watch our csv file for updates
            _watcher = new FileSystemWatcher
            {
                Path = Path.GetDirectoryName(_config.Source),
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = Path.GetFileName(_config.Source)
            };
            
            _watcher.Changed += FileModifiedHandler;
            _watcher.EnableRaisingEvents = true;

            Logger.LogOperations("Watch configured for file " + _config.Source);
        }

        /// <summary>
        /// File modified handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void FileModifiedHandler(object sender, EventArgs e)
        {
            Logger.LogOperations("File modification detected.");
            UpdateStatusVariable(true);
        }

        /// <summary>
        /// Updates the status variable which indicates if the file should be read again or not
        /// </summary>
        /// <param name="updateRequred">if set to <c>true</c> [update requred].</param>
        private void UpdateStatusVariable(bool updateRequred)
        {
            lock (_statusLock)
            {
                _isUpdateRequired = false || updateRequred;
                Logger.LogOperations("Setting isUpdateRequired to " + _isUpdateRequired);
            }
        }

        /// <summary>
        /// Gets the latest data and updates service host
        /// </summary>
        private bool ReadDataAndUpdateServiceHost()
        {
            try
            {
                var dataTable = ReadFromCsv();
                retryCount = 0;
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogWarning(string.Format("Error when attempting to Read and Update! Will attampt again! Error: {0}\nDetails{1}", ex.Message, ex.StackTrace));
                retryCount++;
            }
            return false;
        }

        /// <summary>
        /// Reads from CSV and returns the DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable ReadFromCsv()
        {
            Logger.LogOperations("START Reading from source.");

            var dataTable = new DataTable();
            using (var fileStream = new FileStream(_config.Source, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var textReader = new StreamReader(fileStream))
            {
                var csv = new CsvReader(textReader);
                while (csv.Read())
                {
                    var row = dataTable.NewRow();
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                    }
                    dataTable.Rows.Add(row);
                }
            }
            Logger.LogOperations("FINISHED Reading into DataTable!");
            return dataTable;
        }

        /// <summary>
        /// Validates configuration
        /// </summary>
        /// <param name="fmc"></param>
        public void ValidateConfiguration(DataMonitorConfiguration fmc)
        {
            if (fmc == null)
            {
                Logger.LogError("Configuration was null");
                throw new DataMonitorConfigurationException("Configuration was null", null);
            }

            if (!File.Exists(fmc.Source))
            {
                Logger.LogError("The input file to monitor was invalid or not found: " + fmc.Source);
                throw new DataMonitorConfigurationException("The input file to monitor was invalid or not found: " + fmc.Source, null);
            }
        }
    }
}
