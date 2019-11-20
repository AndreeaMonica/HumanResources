using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResources.Models
{
    public class UpdateEmployeeRequest
    {
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
