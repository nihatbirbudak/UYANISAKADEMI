using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class ClassType : Entity<int>
    {
        public string ClassName { get; set; }
        public string ClassContent { get; set; }

        public virtual List<CourseClassTpye> CourseClassTpyes { get; set; }
    }
}
