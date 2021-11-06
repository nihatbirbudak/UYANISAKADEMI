using System;
using System.Collections.Generic;
using System.Text;

namespace UYK.DTO
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool Active { get; set; }

        public virtual List<ProductDTO> ProductDTO { get; set; }

        
    }
}
