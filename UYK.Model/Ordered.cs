using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class Ordered : Entity<int>
    {
        public int OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool? Shipped { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }

    }
}
