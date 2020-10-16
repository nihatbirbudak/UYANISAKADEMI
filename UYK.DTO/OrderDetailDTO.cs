using System;
using System.Collections.Generic;
using System.Text;

namespace UYK.DTO
{
    public class OrderDetailDTO
    {
        public int ID { get; set; }
        public int? SupplierID { get; set; }
        public int ProductID { get; set; }
        public int OrderedID { get; set; }
        public string OrderNumber { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public int Total { get; set; }

        public bool? FulFilled { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime BillDate { get; set; }

        public virtual SupplierDTO SupplierDTO { get; set; }

        public virtual ProductDTO ProductDTO { get; set; }


        public virtual OrderedDTO OrderedDTO { get; set; }
    }
}
