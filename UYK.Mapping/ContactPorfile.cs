using System;
using System.Collections.Generic;
using System.Text;
using UYK.DTO;
using UYK.Mapping.ConfigProfile;
using UYK.Model;

namespace UYK.Mapping
{
    public class ContactPorfile : ProfileBase
    {
        public ContactPorfile()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
        }
    }
}
