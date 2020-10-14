using System;
using System.Collections.Generic;
using System.Text;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class Size : Entity<int>
    {
        public string SizeValue { get; set; }

        public virtual List<Product> Product { get; set; }


        public Size()
        {
            Product = new List<Product>();

        }
    }
}
