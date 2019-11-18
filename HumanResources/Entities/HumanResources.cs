using System;
using System.Collections.Generic;

namespace HumanResources.Entities
{
    public partial class HumanResources
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }

        public virtual Employees Employee { get; set; }
    }
}
