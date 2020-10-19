using System.Collections.Generic;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class Role : Entity<int>
    {
        public string RoleName { get; set; }

        public virtual List<Customer> Customer { get; set; }

        public Role()
        {
            Customer = new List<Customer>();
        }
    }
}
