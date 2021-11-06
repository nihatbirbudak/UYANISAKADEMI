using System;
using System.Collections.Generic;
using System.Text;

namespace UYK.DTO
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public int? Freight { get; set; }
        public int? SalesTax { get; set; }
        public bool? FulFilled { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? Paid { get; set; }
        public string TransactStatus { get; set; }
        public string ErrLoc { get; set; }
        public string ErrMsg { get; set; }

        public int CustomerId { get; set; }
        public int PaymentId { get; set; }
        public int ShipperId { get; set; }

        public CustomerDTO CustomerDTO { get; set; }
        public PaymentDTO PaymentDTO { get; set; }
        public ShipperDTO ShipperDTO { get; set; }
    }
}
