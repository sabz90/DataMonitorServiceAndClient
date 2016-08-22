using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using CsvHelper;
using DataUpdateServiceModel;
using DataUpdateServiceModel.EventModel;

namespace DataViewer
{
    internal class FormController
    {
        /// <summary>
        /// The form instance
        /// </summary>
        private readonly Form1 _form;

        /// <summary>
        /// The service host
        /// </summary>
        private ServiceHost _host;

        /// <summary>
        /// The data last updated time
        /// </summary>
        private DateTime _dataLastUpdated;

        /// <summary>
        /// The data load lock
        /// </summary>
        private object _dataLoadLock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="FormController"/> class.
        /// </summary>
        /// <param name="form">The form.</param>
        public FormController(Form1 form)
        {
            _form = form;
        }

        /// <summary>
        /// Starts the data update service.
        /// </summary>
        public void StartDataUpdateService()
        {
            var ds = new DataUpdateService();
            ds.OnDataUpdate += DataSource_Updated;
            var serviceStartSuccessful = false;
            
            try
            {
                _host = new ServiceHost(ds);
                var behaviour = _host.Description.Behaviors.Find<ServiceBehaviorAttribute>();
                behaviour.InstanceContextMode = InstanceContextMode.Single;
                _host.Open();
                serviceStartSuccessful = true;
            }
            catch (Exception ex)
            {
               LogMessage("Failed to start service. \nDetails:\n" + ex.Message);
            }

            if (serviceStartSuccessful)
            {
                LogMessage("Service Started at Uri:" + string.Join(", ", _host.BaseAddresses));
                _form.Invoke((MethodInvoker) delegate()
                {
                    _form.btnStart.Enabled = false;
                    _form.btnStop.Enabled = true;
                    _form.tbServiceStatus.Text = "Service Started at Uri:" + string.Join(", ", _host.BaseAddresses);
                });
            }
        }

        /// <summary>
        /// Handles the event when a dataupdate is received from the self hosted wcf service
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataUpdateEventArgs"/> instance containing the event data.</param>
        private void DataSource_Updated(object sender, DataUpdateEventArgs e)
        {
            _dataLastUpdated = DateTime.Now;
            LogMessage("Data Update Request Received at " + _dataLastUpdated);
            UpdateDataGridView(e.DataSet.Tables[0]);
        }

        /// <summary>
        /// Updates the data grid view.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        private void UpdateDataGridView(object dataSource)
        {
            lock (_dataLoadLock)
            {
                _form.Invoke((MethodInvoker) delegate()
                {
                    _form.dataGridView.DataSource = dataSource;
                    foreach (DataGridViewRow row in _form.dataGridView.Rows)
                    {
                        row.HeaderCell.Value = (row.Index + 1).ToString();
                    }
                    _form.dataGridView.RowHeadersWidth = 70;

                    _form.lbLastUpdated.Text = _dataLastUpdated.ToString();
                });
                LogMessage("Data loaded Successfully!");
            }
        }

        /// <summary>
        /// Stops the data update service.
        /// </summary>
        public void StopDataUpdateService()
        {
            _host.Close();
            _form.Invoke((MethodInvoker) delegate()
            {
                _form.btnStart.Enabled = true;
                _form.btnStop.Enabled = false;
                _form.tbServiceStatus.Text = "Service Stopped";
            });
            LogMessage("Service Stopped at " + DateTime.Now);
        }

        /// <summary>
        /// Processes the form close.
        /// </summary>
        public void ProcessFormClose()
        {
            _host?.Close();
        }

        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        private void LogMessage(string msg)
        {
            msg = msg.Replace("\n", Environment.NewLine);
            _form.Invoke((MethodInvoker) delegate()
            {
                _form.tbLog.Text += "------------" + 
                                    DateTime.Now + 
                                    Environment.NewLine + 
                                    msg + 
                                    Environment.NewLine + Environment.NewLine;
                _form.tbLog.ScrollToCaret();
            });
        }

        /// <summary>
        /// Loads the data from configured source.
        /// </summary>
        public void LoadDataFromConfiguredSource()
        {
            try
            {
                _form.Invoke((MethodInvoker) delegate()
                {
                    _form.btnManualLoad.Enabled = false;
                });

                var sourceCsvPath = ConfigurationManager.AppSettings["CsvSourcePath"];
                LogMessage("Attempting to load data from source:\n" + sourceCsvPath);

                var dataTable = new DataTable {TableName = "CsvData"};

                using (var fileStream = new FileStream(sourceCsvPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var textReader = new StreamReader(fileStream))
                {
                    var csv = new CsvReader(textReader);
                    csv.ReadHeader();
                    var headers = csv.FieldHeaders;

                    foreach (var header in headers)
                    {
                        dataTable.Columns.Add(header);
                    }

                    while (csv.Read())
                    {
                        dataTable.Rows.Add(csv.CurrentRecord.Take(dataTable.Columns.Count).ToArray());
                    }
                }
                UpdateDataGridView(dataTable);
            }
            catch (Exception ex)
            {
                LogMessage("ERROR WHEN LOADING FROM CSV.\nDetails:\n" + ex.Message);
            }
            finally
            {
                _form.Invoke((MethodInvoker)delegate ()
                {
                    _form.btnManualLoad.Enabled = true;
                });
            }
        }
    }
}
