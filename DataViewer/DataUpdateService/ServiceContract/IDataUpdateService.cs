using System.Data;
using System.ServiceModel;

namespace DataUpdateService
{
    [ServiceContract]
    public interface IDataUpdateService
    {
        [OperationContract]
        bool UpdateData(DataSet name);
    }
}