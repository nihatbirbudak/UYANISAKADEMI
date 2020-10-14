using System.Collections.Generic;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class Category : Entity<int>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool Active { get; set; }

        public virtual List<Product> Product { get; set; }

        public Category()
        {
            Product = new List<Product>();
        }
    }
}
