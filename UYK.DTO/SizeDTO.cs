using System;
using System.Collections.Generic;
using System.Text;

namespace UYK.DTO
{
    public class SizeDTO
    {
        public int ID { get; set; }
        public string SizeValue { get; set; }

        public virtual List<ProductDTO> ProductDTO { get; set; }


        public SizeDTO()
        {
            ProductDTO = new List<ProductDTO>();

        }
    }
}
