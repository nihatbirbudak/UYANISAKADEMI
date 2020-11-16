using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UYK.Core.Entities;

namespace UYK.DTO
{
    public class CourseCategoryTypeDTO 
    {
        public int Id { get; set; }
        [Display(Name ="Kategori Adı")]
        public string CategoryName { get; set; }
        [Display(Name = "Acıklama")]
        public string Description { get; set; }
    }
}
