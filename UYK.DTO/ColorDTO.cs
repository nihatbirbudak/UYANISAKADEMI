using System;
using System.Collections.Generic;
using System.Text;

namespace UYK.DTO
{
    public class ColorDTO
    {
        public int ID { get; set; }
        public string ColorValue { get; set; }

        public virtual List<ProductDTO> ProductDTO { get; set; }

        public ColorDTO()
        {
            ProductDTO = new List<ProductDTO>();
        }
    }
}
