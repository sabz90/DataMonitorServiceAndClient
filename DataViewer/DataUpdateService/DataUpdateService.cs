using System.Data;
using DataUpdateServiceModel.EventModel;
using DataUpdateServiceModel.ServiceContract;

namespace DataUpdateServiceModel
{
    /// <summary>
    /// Data Update Service
    /// </summary>
    /// <seealso cref="DataUpdateServiceModel.ServiceContract.IDataUpdateService" />
    public class DataUpdateService : IDataUpdateService
    {
        /// <summary>
        /// Occurs when [on data update].
        /// </summary>
        public event DataUpdateEventHandler OnDataUpdate;

        /// <summary>
        /// Updates the data.
        /// </summary>
        /// <param name="dataSet">The data set.</param>
        /// <returns></returns>
        public bool UpdateData(DataSet dataSet)
        {
            if (OnDataUpdate != null)
            {
                OnDataUpdate(this, new DataUpdateEventArgs(dataSet));
            }
            return true;
        }
    }

    
}
