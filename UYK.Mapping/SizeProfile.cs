using System;
using System.Collections.Generic;
using System.Text;
using UYK.DTO;
using UYK.Mapping.ConfigProfile;
using UYK.Model;

namespace UYK.Mapping
{
    public class SizeProfile : ProfileBase
    {
        public SizeProfile()
        {
            CreateMap<Size, SizeDTO>().ReverseMap();
        }
    }
}
