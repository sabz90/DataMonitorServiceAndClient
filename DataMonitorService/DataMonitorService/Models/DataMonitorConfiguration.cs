using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataMonitorService.Models.Exceptions;
using DataMonitorService.Utilities;

namespace DataMonitorService.Models
{
    internal class DataMonitorConfiguration
    {
        public string Source { get; set; }

        public SourceType Type { get; set; }

        public DataMonitorConfiguration()
        {

        }
    }
}
