using System;
using System.Collections.Generic;
using System.Text;

namespace UYK.DTO
{
    public class RoleDTO
    {
        public int ID { get; set; }
        public string RoleName { get; set; }

        public virtual List<CustomerDTO> CustomerDTO { get; set; }

        public RoleDTO()
        {
            CustomerDTO = new List<CustomerDTO>();
        }
    }
}
