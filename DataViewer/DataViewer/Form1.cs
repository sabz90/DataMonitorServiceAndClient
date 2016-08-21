using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using DataUpdateService.EventModel;
using DataUpdateService = DataUpdateService.DataUpdateService;

namespace DataViewer
{
    public partial class Form1 : Form
    {
        private ServiceHost host;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            global::DataUpdateService.DataUpdateService ds = new global::DataUpdateService.DataUpdateService();
            ds.OnDataUpdate += DataSource_Updated;

            host = new ServiceHost(ds);
            var behaviour = host.Description.Behaviors.Find<ServiceBehaviorAttribute>();
            behaviour.InstanceContextMode = InstanceContextMode.Single;
            host.Open();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblStatusMessage.Text = "Service Started at Uri:" + String.Join(", ", host.BaseAddresses);

            PopulateGrid();
        }

        private void PopulateGrid()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            // Here we add five DataRows.
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            dataGridView.DataSource = table;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            host.Close();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            lblStatusMessage.Text = "Service Stopped";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            host.Close();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void DataSource_Updated(object sender, DataUpdateEventArgs e)
        {
            dataGridView.DataSource = e.DataSet.Tables[0];
        }
    }
}
