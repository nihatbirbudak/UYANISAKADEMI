using System.Collections.Generic;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class Payment : Entity<int>
    {
        public string PaymentType { get; set; }
        public bool Allowed { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
