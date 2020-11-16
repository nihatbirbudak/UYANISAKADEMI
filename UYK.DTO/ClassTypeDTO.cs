using System.Collections.Generic;

namespace UYK.DTO
{
    public class ClassTypeDTO
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string ClassContent { get; set; }

        public List<CourseDTO> CourseDTOs { get; set; }
    }
}