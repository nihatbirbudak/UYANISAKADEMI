using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UYK.DTO
{
    public class ProductDTO
    {
        public int ID { get; set; }
        [Display(Name = "Başlık")]
        public string ProductName { get; set; }
        [Display(Name = "Açıklama")]
        public string ProductDescription { get; set; }
        [Display(Name = "Fiyat")]
        public int UnitPrice { get; set; }
        [Display(Name = "İnidim Oranı" )]
        public int Discount { get; set; }
        [Display(Name = "Resim")]
        public string Picture { get; set; }
        [Display(Name = "İnidirim Oranı")]
        public bool DiscountAvailable { get; set; }
        public bool CurrentOrder { get; set; }
        [Display(Name = "Kota")]
        public int QuantityPerUnit { get; set; }


        public int? ActivityId { get; set; }
        public int? CategoryId { get; set; }
        [Display(Name = "Tedarikçi")]
        public int? SupplierId { get; set; }
        public int? SizeId { get; set; }
        public int? ColorId { get; set; }



        public virtual ActivityDTO ActivityDTO { get; set; }
        public virtual SizeDTO SizeDTO { get; set; }
        public virtual ColorDTO ColorDTO { get; set; }
        public virtual SupplierDTO SupplierDTO { get; set; }
        public virtual List<OrderDetailDTO> OrderDetailDTO { get; set; }
        public virtual CategoryDTO CategoryDTO { get; set; }
    }
}
