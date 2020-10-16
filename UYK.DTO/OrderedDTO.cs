using System;
using System.Collections.Generic;
using System.Text;

namespace UYK.DTO
{
    public class OrderedDTO
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool? Shipped { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        public CustomerDTO CustomerDTO { get; set; }
        public virtual List<OrderDetailDTO> OrderDetailDTO { get; set; }

        public OrderedDTO()
        {
            OrderDetailDTO = new List<OrderDetailDTO>();
        }
    }
}
