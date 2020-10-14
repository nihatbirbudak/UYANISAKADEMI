using System;
using System.Collections.Generic;
using System.Text;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class Payment : Entity<int>
    {
        public string PaymentType { get; set; }
        public bool Allowed { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
