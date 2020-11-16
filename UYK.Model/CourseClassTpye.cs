using System;
using System.Collections.Generic;
using System.Text;

namespace UYK.Model
{
    public class CourseClassTpye
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int ClassTypeId { get; set; }
        public ClassType ClassType { get; set; }
    }
}
