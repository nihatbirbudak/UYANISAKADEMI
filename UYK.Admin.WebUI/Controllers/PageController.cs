using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UYK.BLL.Services.Abstract;
using UYK.DTO;
using UYK.Model;
using UYK.WebUI.Admin.Models;

namespace UYK.WebUI.Admin.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class PageController : BaseController
    {
        private IAboutService aboutService;
        private ICustomerService customerService;
        private IContactService contactService;
        private ICourseCategoryTypeService courseCategoryTypeService;
        private ICourseService courseService;
        public PageController(IAboutService aboutService, ICustomerService customerService, IContactService contactService, ICourseCategoryTypeService courseCategoryTypeService, ICourseService courseService)
        {
            this.aboutService = aboutService;
            this.customerService = customerService;
            this.contactService = contactService;
            this.courseCategoryTypeService = courseCategoryTypeService;
            this.courseService = courseService;
        }

        #region About Setting
        public IActionResult AboutAdd()
        {
            if (aboutService.getAll().ToList().Count() == 0)
            {
                var model = new AboutViewModel();
                model.CurrentUser = CurrentUser;
                return View(model);
            }
            else
            {
                return RedirectToAction("AboutUpdate");
            }
            
        }
        [HttpPost]
        public IActionResult AboutAdd(AboutDTO aboutDTO, IFormFile file)
        {
            AddFile(file, aboutDTO);
            aboutDTO.CustomerId = CurrentUser.ID;
            aboutDTO.UpdateDate = DateTime.UtcNow;
            aboutService.newEntity(aboutDTO);
            return RedirectToAction("AboutUpdate");
        }
  
        public IActionResult AboutUpdate()
        {
            var model = new AboutViewModel();
            model.CurrentUser = CurrentUser;
            model.AboutDTO = aboutService.getAll()[0];
            model.UpdatedUser = customerService.getEntity(model.AboutDTO.CustomerId);
            return View(model);
        }
        [HttpPost]
        public IActionResult AboutUpdate(AboutDTO aboutDTO, IFormFile file)
        {
            if (aboutDTO.image != null)
            {
                DeleteFile(file, aboutDTO);
            }
            AddFile(file, aboutDTO);
            aboutDTO.CustomerId = CurrentUser.ID;
            aboutDTO.UpdateDate = DateTime.UtcNow;
            aboutService.updateEntity(aboutDTO);
            return RedirectToAction("AboutUpdate");
        }

        #endregion

        #region Contact Setting
        public IActionResult ContactAdd()
        {
            if (contactService.getAll().ToList().Count() == 0 )
            {
                var model = new ContactViewModel();
                model.CurrentUser = CurrentUser;
                return View(model);
            }
            else
            {
                return RedirectToAction("ContactUpdate");
            }
        }
        [HttpPost]
        public IActionResult ContactAdd(ContactDTO contactDTO)
        {
            contactService.newEntity(contactDTO);
            return RedirectToAction("ContactUpdate");
        }

        public IActionResult ContactUpdate()
        {
            var model = new ContactViewModel();
            model.CurrentUser = CurrentUser;
            model.ContactDTO = contactService.getAll()[0];
            return View(model);
        }
        public IActionResult ContactUpdate(ContactDTO contactDTO)
        {
            contactService.updateEntity(contactDTO);
            return RedirectToAction("UpdateUser");
        }
        #endregion

        #region Course Category Setting
        [HttpGet]
        public IActionResult CourseCategoryAdd(int id)
        {
            CourseCategoryTypeViewModel model = new CourseCategoryTypeViewModel();
            model.CurrentUser = CurrentUser;
            model.courseCategoryTypeDTOs = courseCategoryTypeService.getAll();
            model.ChangeId = id;
            Dictionary<int, int> catCount = new Dictionary<int, int>();
            foreach (var type in courseService.getCategoryCount())
            {
                int key = type.Key;
                var value = type.Value.Count();
                catCount.Add(key, value);
            }
            model.CategoryCount = catCount;
            return View(model);
        }
        [HttpPost]
        public IActionResult CourseCategoryAdd(CourseCategoryTypeDTO courseCategoryTypeDTO)
        {
            courseCategoryTypeService.newEntity(courseCategoryTypeDTO);
            return RedirectToAction("CourseCategoryAdd");
        }
        public IActionResult CourseCategoryDelete(int id)
        {
            Dictionary<int, int> catCount = new Dictionary<int, int>();
            foreach (var type in courseService.getCategoryCount())
            {
                int key = type.Key;
                var value = type.Value.Count();
                catCount.Add(key, value);
            }
            if (!catCount.ContainsKey(id))
            {
                courseCategoryTypeService.deleteEntity(id);
            }
            return RedirectToAction("CourseCategoryAdd");
        }
        [HttpPost]
        public IActionResult CourseCategoryEdit(CourseCategoryTypeDTO courseCategoryTypeDTO)
        {
            courseCategoryTypeService.updateEntity(courseCategoryTypeDTO);
            return RedirectToAction("CourseCategoryAdd");
        } 
        #endregion





        #region Used Method
        public async void AddFile(IFormFile file, AboutDTO aboutDTO)
        {
            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\MyImg", randomName);
                aboutDTO.image = randomName;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
        }

        public void DeleteFile(IFormFile file , AboutDTO aboutDTO)
        {
            var pathDelete = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\MyImg", aboutDTO.image);
            FileInfo fi = new FileInfo(pathDelete);
            if (fi != null)
            {
                System.IO.File.Delete(pathDelete);
                fi.Delete();
            }
        }
        #endregion
    }
}
