using System.Collections.Generic;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class Color : Entity<int>
    {
        public string ColorValue { get; set; }

        public virtual List<Product> Product { get; set; }

        public Color()
        {
            Product = new List<Product>();
        }
    }
}
