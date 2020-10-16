using System;
using System.Collections.Generic;
using System.Text;

namespace UYK.DTO
{
    public class ComplaintDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int CustomerID { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual CustomerDTO CustomerDTO { get; set; }
    }
}
