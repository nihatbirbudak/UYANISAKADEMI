using System;
using System.Collections.Generic;
using System.Text;

namespace UYK.DTO
{
    public class PaymentDTO
    {
        public int ID { get; set; }
        public string PaymentType { get; set; }
        public bool Allowed { get; set; }

        public virtual List<OrderDTO> OrdersDTO { get; set; }
    }
}
