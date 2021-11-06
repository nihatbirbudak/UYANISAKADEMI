using System.Collections.Generic;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class Role : Entity<int>
    {
        public string RoleName { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }


    }
}
