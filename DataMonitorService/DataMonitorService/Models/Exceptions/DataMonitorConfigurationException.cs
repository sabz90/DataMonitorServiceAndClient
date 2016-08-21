using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMonitorService.Models.Exceptions
{
    /// <summary>
    /// DataMonitorConfigurationException
    /// </summary>
    /// <seealso cref="System.Exception" />
    class DataMonitorConfigurationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataMonitorConfigurationException"/> class.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="innerException">The inner exception.</param>
        public DataMonitorConfigurationException(string msg, Exception innerException) : base(msg)
        {
        }
    }
}
