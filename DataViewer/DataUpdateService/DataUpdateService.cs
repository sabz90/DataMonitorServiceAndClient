using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataUpdateService.EventModel;

namespace DataUpdateService
{
    public class DataUpdateService : IDataUpdateService
    {
        public event DataUpdateEventHandler OnDataUpdate;

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
