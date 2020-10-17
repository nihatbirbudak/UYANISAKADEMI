using System.Collections.Generic;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class Shipper : Entity<int>
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
