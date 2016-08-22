using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using DataUpdateServiceModel.EventModel;
using DataUpdateServiceModel;

namespace DataViewer
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// form controller that helps in taking actions specific to this form.
        /// </summary>
        private readonly FormController _formController;

        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            _formController = new FormController(this);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _formController.StartDataUpdateService();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _formController.StopDataUpdateService();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _formController.ProcessFormClose();
        }

        private void btnManualLoad_Click(object sender, EventArgs e)
        {
            var dataLoadTask = new Task(_formController.LoadDataFromConfiguredSource);
            dataLoadTask.Start();
        }
    }
}
