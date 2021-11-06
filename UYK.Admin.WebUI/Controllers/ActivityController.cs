using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using UYK.BLL.Services.Abstract;
using UYK.DTO;
using UYK.WebUI.Admin.Models;

namespace UYK.WebUI.Admin.Controllers
{
    [Authorize(Roles = "Admin,Manager,Teacher")]
    public class ActivityController : BaseController
    {
        private ICourseService courseService;
        private ICustomerService customerService;
        private IRoleService roleService;
        private IActivityService activityService;
        private IProductService productService;
        private ISupplierService supplierService;
        public ActivityController(ICourseService courseService,ICustomerService customerService,IRoleService roleService,IActivityService activityService,IProductService productService,ISupplierService supplierService)
        {
            this.courseService = courseService;
            this.customerService = customerService;
            this.roleService = roleService;
            this.activityService = activityService;
            this.productService = productService;
            this.supplierService = supplierService;
        }
        public IActionResult AddActivity()
        {
            var model = new ActivityViewModel();
            model.CurrentUser = CurrentUser;
            model.CourseDTOs = courseService.getAll();
            model.CustomerDTOs = customerService.getAllUserinRole(roleService.getRoleName("Instructor").ID);
            model.SupplierDTOs = supplierService.getAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult AddActivity(ActivityDTO activityDTO,ProductDTO productDTO, IFormFile File)
        {
            AddFile(File, productDTO);
            var time = new DateTime();
            activityDTO.StartTime = activityDTO.StartTime; 
            productDTO.ActivityDTO = activityDTO;
            productService.newEntity(productDTO);
            return RedirectToAction("ActivityList");
        }

        public IActionResult ActivityList()
        {
            var model = new ActivityViewModel();
            model.CurrentUser = CurrentUser;
            model.ActivityDTOs = activityService.getAll();
            model.CourseDTOs = courseService.getAll();
            model.CustomerDTOs = customerService.getAll();
            model.ProductDTOs = productService.getAll();
            model.SupplierDTOs = supplierService.getAll();
            return View(model);
        }

        #region  Methods
        public async void AddFile(IFormFile file, ProductDTO productDTO)
        {
            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\MyImg\\EducationImg", randomName);
                productDTO.Picture = randomName;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
        }

        public void DeleteFile(ProductDTO productDTO)
        {
            if (productDTO.Picture != null)
            {
                var pathDelete = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\MyImg\\EducationImg", productDTO.Picture);
                FileInfo fi = new FileInfo(pathDelete);
                if (fi != null)
                {
                    System.IO.File.Delete(pathDelete);
                    fi.Delete();
                }
            }

        }
        #endregion

    }
}
