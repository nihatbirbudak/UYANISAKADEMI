using System;
using System.Collections.Generic;
using System.Text;

namespace UYK.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseTitle { get; set; }
        public string CourseMainContent { get; set; }
        public string CourseContent { get; set; }
        public string CourseForWho { get; set; }
        public string CourseTarget { get; set; }
        public string CourseSubjects { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsApply { get; set; }

        public int ClassTypeId { get; set; }
        public ClassTypeDTO ClassTypeDTO { get; set; }

        public int CustomerId { get; set; }
        public CustomerDTO CustomerDTO { get; set; }

        public int CourseCategoryTypeId { get; set; }
        public CourseCategoryTypeDTO CourseCategoryTypeDTO { get; set; }
    }
}
