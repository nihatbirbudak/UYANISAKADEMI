using System;
using System.Collections.Generic;
using System.Text;
using UYK.Core.Entities;

namespace UYK.Model
{
    public class CourseCategoryType : Entity<int>
    {
        public string CategoryName { get; set; }
    }
}
