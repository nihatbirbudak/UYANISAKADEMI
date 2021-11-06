
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class Product : Entity<int>
    {
        
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int UnitPrice { get; set; }
        public int Discount { get; set; }
        public string Picture { get; set; }
        public bool? DiscountAvailable { get; set; }
        public bool? CurrentOrder { get; set; }
        public int QuantityPerUnit { get; set; }
  
        public int? ActivityId { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public int? SizeId { get; set; }
        public int? ColorId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Size Size { get; set; }
        public virtual Color Color { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<ProductCategories> ProductCategories { get; set; }


    }
}
