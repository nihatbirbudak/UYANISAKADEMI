using System.Collections.Generic;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class Shipper : Entity<int>
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
