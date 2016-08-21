using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Timers;
using DataMonitorService.Interfaces;
using DataMonitorService.Models;
using DataMonitorService.Models.Exceptions;
using DataMonitorService.Utilities;
using System.IO;
using UpdateStatus = DataMonitorService.Models.UpdateStatus;

namespace DataMonitorService.DataMonitor
{
    internal class CsvFileMonitor: IDataMonitor
    {
        private string _csvFilePath; 
        private DateTime _lastUpdated;
        private UpdateStatus _status;
        private readonly string _csvConString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Extended Properties='TEXT;HDR=YES;FMT=Delimited'";

        /// <summary>
        /// Configures the data monitor and also validates the configuration
        /// </summary>
        /// <param name="fmc"></param>
        public void Configure(DataMonitorConfiguration fmc)
        {
            ValidateConfiguration(fmc);

            _csvFilePath = fmc.Source;
        }

        /// <summary>
        /// Checks if update is required. If it is, it sends data to the service host.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckAndUpate(object sender, ElapsedEventArgs e)
        {
            DateTime fileLastModified;
            if (IsDataUpdateRequired(out fileLastModified))
            {
                _status = UpdateStatus.Updating;

                ReadDataAndUpdateServiceHost();

                _status = UpdateStatus.Finished;
                _lastUpdated = fileLastModified;
            }
        }

        /// <summary>
        /// Gets the latest data and updates service host
        /// </summary>
        private void ReadDataAndUpdateServiceHost()
        {
            var dataTable = ReadFromCsv();
        }

        /// <summary>
        /// Reads from CSV and returns the DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable ReadFromCsv()
        {
            var conStr = string.Format(_csvConString, Path.GetDirectoryName(_csvFilePath));
            DataTable dataTable;

            //Read Data from the First Sheet.
            using (var con = new OleDbConnection(conStr))
            {
                using (var cmd = new OleDbCommand())
                {
                    using (var oda = new OleDbDataAdapter())
                    {
                        dataTable = new DataTable();
                        cmd.CommandText = "SELECT * From [" + Path.GetFileName(_csvFilePath) + "]";
                        cmd.Connection = con;
                        con.Open();
                        oda.SelectCommand = cmd;
                        oda.Fill(dataTable);
                        con.Close();
                    }
                }
            }
            return dataTable;
        }

        /// <summary>
        /// Checks if data update is required.
        /// </summary>
        /// <param name="fileLastModified"></param>
        /// <returns></returns>
        private bool IsDataUpdateRequired(out DateTime fileLastModified)
        {
            fileLastModified = File.GetLastWriteTime(_csvFilePath);
            return (_status != UpdateStatus.Updating) && (fileLastModified > _lastUpdated);
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
                throw new DataMonitorConfigurationException("Configuration was null");
            }

            if (!File.Exists(fmc.Source))
            {
                Logger.LogError("The input file to monitor was invalid or not found: " + fmc.Source);
                throw new DataMonitorConfigurationException("The input file to monitor was invalid or not found: " + fmc.Source);
            }
        }
    }
}
