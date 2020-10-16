using System;
using System.Collections.Generic;
using System.Text;

namespace UYK.DTO
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public int SupplierID { get; set; }

        public int CategoryID { get; set; }
        public int UnitPrice { get; set; }

        public int SizeID { get; set; }

        public int ColorID { get; set; }
        public int Discount { get; set; }
        public string Picture { get; set; }
        public bool? DiscountAvailable { get; set; }
        public bool? CurrentOrder { get; set; }
        public int? QuantityPerUnit { get; set; }

        public virtual CategoryDTO CategoryDTO { get; set; }
        public virtual SizeDTO SizeDTO { get; set; }
        public virtual ColorDTO ColorDTO { get; set; }
        public virtual SupplierDTO SupplierDTO { get; set; }

        public virtual List<OrderDetailDTO> OrderDetailDTO { get; set; }
    }
}
