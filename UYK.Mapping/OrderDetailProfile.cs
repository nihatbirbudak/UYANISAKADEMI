using System;
using System.Collections.Generic;
using System.Text;
using UYK.DTO;
using UYK.Mapping.ConfigProfile;
using UYK.Model;

namespace UYK.Mapping
{
    public class OrderDetailProfile : ProfileBase
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
        }
    }
}
