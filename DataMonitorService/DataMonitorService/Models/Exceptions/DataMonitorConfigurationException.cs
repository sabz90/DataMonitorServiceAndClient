using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMonitorService.Models.Exceptions
{
    class DataMonitorConfigurationException : Exception
    {
        public DataMonitorConfigurationException(string msg) : base(msg)
        {
        }
    }
}
