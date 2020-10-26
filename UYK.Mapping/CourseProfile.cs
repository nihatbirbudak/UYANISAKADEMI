using System;
using System.Collections.Generic;
using System.Text;
using UYK.DTO;
using UYK.Mapping.ConfigProfile;
using UYK.Model;

namespace UYK.Mapping
{
    public class CourseProfile : ProfileBase
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
        }
    }
}
