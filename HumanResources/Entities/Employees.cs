using System;
using System.Collections.Generic;

namespace HumanResources.Entities
{
    public partial class Employees
    {
        public Employees()
        {
            HumanResources = new HashSet<HumanResources>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateHired { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual ICollection<HumanResources> HumanResources { get; set; }
    }
}
