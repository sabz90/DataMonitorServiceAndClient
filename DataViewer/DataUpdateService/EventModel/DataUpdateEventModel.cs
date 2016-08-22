using System;
using System.Data;

namespace DataUpdateServiceModel.EventModel
{
    /// <summary>
    /// Data Update Event Handler
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="e">The <see cref="DataUpdateEventArgs"/> instance containing the event data.</param>
    public delegate void DataUpdateEventHandler(object source, DataUpdateEventArgs e);

    /// <summary>
    /// Data Update Event args. Holds the dataset
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class DataUpdateEventArgs : EventArgs
    {
        public DataSet DataSet { get; private set; }

        public DataUpdateEventArgs(DataSet dataSet)
        {
            DataSet = dataSet;
        }
    }
}
