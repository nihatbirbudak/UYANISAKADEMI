using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UYK.DTO;

namespace UYK.WebUI.Admin.Models
{
    public class ActivityViewModel : IBaseViewModel
    {
        public CustomerDTO CurrentUser { get; set; }
        public List<CourseDTO> CourseDTOs { get; set; }
        public ActivityDTO ActivityDTO { get; set; }
        public List<CustomerDTO> CustomerDTOs { get; set; }
        public IFormFile File { get; set; }
        public ProductDTO ProductDTO { get; set; }
        public List<SupplierDTO> SupplierDTOs { get; set; }
        public List<ActivityDTO> ActivityDTOs { get; set; }
        public List<ProductDTO> ProductDTOs { get; set; }
    }
}
