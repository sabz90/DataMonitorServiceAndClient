using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataUpdateService.EventModel
{
    public delegate void DataUpdateEventHandler(object source, DataUpdateEventArgs e);
    public class DataUpdateEventArgs : EventArgs
    {
        public DataSet DataSet { get; private set; }

        public DataUpdateEventArgs(DataSet dataSet)
        {
            DataSet = dataSet;
        }
    }
}
