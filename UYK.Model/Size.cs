using System.Collections.Generic;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class Size : Entity<int>
    {
        public string SizeValue { get; set; }

        public virtual ICollection<Product> Product { get; set; }

    }
}
