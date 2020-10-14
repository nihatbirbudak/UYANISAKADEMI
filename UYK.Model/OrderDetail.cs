using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class OrderDetail : Entity<int>
    {
        [ForeignKey("Supplier")]
        public int? SupplierID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        [ForeignKey("Ordered")]
        public int OrderedID { get; set; }
        public string OrderNumber { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public int Total { get; set; }

        public bool? FulFilled { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime BillDate { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Product Product { get; set; }


        public virtual Ordered Ordered { get; set; }
    }
}
