using System;
using System.Collections.Generic;
using System.Text;

namespace UYK.DTO
{
    public class ShipperDTO
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual List<OrderDTO> OrdersDTO { get; set; }
    }
}
