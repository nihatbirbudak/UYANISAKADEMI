using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class Course : Entity<int>
    {
        public string CourseName { get; set; }
        public string CourseTitle { get; set; }
        public string CourseMainContent { get; set; }
        public string CourseContent { get; set; }
        public string CourseForWho { get; set; }
        public string CourseTarget { get; set; }
        public string CourseSubjects { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsApply { get; set; }
        public string Image { get; set; }

        public virtual List<CourseClassTpye> CourseClassTpyes { get; set; }


        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("CourseCategoryTypeId")]
        public int CourseCategoryTypeId { get; set; }
        public CourseCategoryType CourseCategoryType { get; set; }

    }
}
