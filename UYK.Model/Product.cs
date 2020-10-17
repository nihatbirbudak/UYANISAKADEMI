
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class Product : Entity<int>
    {
        
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        [ForeignKey("SupplierID")]
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public int UnitPrice { get; set; }
        [ForeignKey("SizeID")]
        public int SizeID { get; set; }
        [ForeignKey("ColorID")]
        public int ColorID { get; set; }
        public int Discount { get; set; }
        public string Picture { get; set; }
        public bool? DiscountAvailable { get; set; }
        public bool? CurrentOrder { get; set; }
        public int? QuantityPerUnit { get; set; }

        public virtual Size Size { get; set; }
        public virtual Color Color { get; set; }
        public virtual Supplier Supplier { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
        public List<ProductCategories> ProductCategories { get; set; }

    }
}
