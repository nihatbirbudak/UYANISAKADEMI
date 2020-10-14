using System;
using System.Collections.Generic;
using System.Text;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class ProductDetail : Entity<int>
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
    }
}
