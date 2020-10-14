
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using UYK.Core.Entities;

namespace UYK.Model
{
    public class Product : Entity<int>
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierID { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public int UnitPrice { get; set; }
        [ForeignKey("Size")]
        public int SizeID { get; set; }
        [ForeignKey("Color")]
        public int ColorID { get; set; }
        public int Discount { get; set; }
        public string Picture { get; set; }
        public bool? DiscountAvailable { get; set; }
        public bool? CurrentOrder { get; set; }
        public int? QuantityPerUnit { get; set; }

        public virtual Category Category { get; set; }
        public virtual Size Size { get; set; }
        public virtual Color Color { get; set; }
        public virtual Supplier Supplier { get; set; }

        public virtual List<OrderDetail> OrderDetail { get; set; }
    }
}
