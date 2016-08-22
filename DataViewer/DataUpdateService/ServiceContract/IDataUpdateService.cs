using System.Data;
using System.ServiceModel;

namespace DataUpdateServiceModel.ServiceContract
{
    [ServiceContract]
    public interface IDataUpdateService
    {
        [OperationContract]
        bool UpdateData(DataSet name);
    }
}