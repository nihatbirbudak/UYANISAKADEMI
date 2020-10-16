using System;
using System.Collections.Generic;
using System.Text;
using UYK.DTO;
using UYK.Mapping.ConfigProfile;
using UYK.Model;

namespace UYK.Mapping
{
    public class ProductProfile : ProfileBase
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
