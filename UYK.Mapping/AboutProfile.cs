
using UYK.DTO;
using UYK.Mapping.ConfigProfile;
using UYK.Model;

namespace UYK.Mapping
{
    public class AboutProfile : ProfileBase
    {
        public AboutProfile()
        {
            CreateMap<About, AboutDTO>().ReverseMap();
        }
    }
}
