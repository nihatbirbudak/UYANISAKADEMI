using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UYK.BLL.Services.Abstract;
using UYK.DTO;
using UYK.WebUI.Admin.Core;
using UYK.WebUI.Admin.Models;

namespace UYK.WebUI.Admin.Controllers
{
    public class LoginController : BaseController
    {
        
        private readonly ICustomerService customerService;
        private readonly IRoleService roleService;
        private readonly ICourseService courseService;
        private readonly ICourseCategoryTypeService courseCategoryTypeService;
        private readonly IClassTypeService classTypeService;
        public LoginController(ICustomerService _customerService, IRoleService _roleService, ICourseService courseService, ICourseCategoryTypeService courseCategoryTypeService,IClassTypeService classTypeService)
        {
            customerService = _customerService;
            roleService = _roleService;
            this.courseService = courseService;
            this.courseCategoryTypeService = courseCategoryTypeService;
            this.classTypeService = classTypeService;
        }
        
        public ActionResult UserLogin()
        {
            Seed();
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(LoginViewModel userModel)
        {
            var user = customerService.FindwithUsernameandMail(userModel.UserName, userModel.Password);
            if (user != null)
            {
                user.RoleDTO = roleService.getEntity((int)user.RoleId);
                var userClaims = new List<Claim>()
                {
                       new Claim("CustomerDTO",UYKConvert.UYKJsonSerialize(user))
                };
                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                var userProps = new AuthenticationProperties 
                {
                    IsPersistent = userModel.RememberMe,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
                };
                HttpContext.SignInAsync(userPrincipal,userProps);
                if (user.RememberMe != userModel.RememberMe)
                {
                    user.RememberMe = userModel.RememberMe;
                    customerService.updateEntity(user);
                }
                return RedirectToAction("Index", "Home");
                

            }
            return View(user);
        }
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("UserLogin");
        }
        [HttpGet]
        public ActionResult AccessDenied()
        {
            return View();
        }


        public void Seed()
        {
            var role = new RoleDTO();
            role.RoleName = "Admin";
            roleService.newEntity(role);
            var admin = new CustomerDTO 
            { 
                FirstName ="Nihat",
                LastName ="Birbudak",
                Email ="nihat@mail.com",
                Password ="1234",
                UserName ="nbirbudak",
                RoleId =1,
            };
            customerService.newEntity(admin);
            if (courseCategoryTypeService.getAll().Count() == 0)
            {
                List<CourseCategoryTypeDTO> ccType = new List<CourseCategoryTypeDTO>()
                {
                   new CourseCategoryTypeDTO { CategoryName = "Eğtim" },
                   new CourseCategoryTypeDTO { CategoryName = "Seminler" },
                   new CourseCategoryTypeDTO { CategoryName = "Seans" }
                };
                foreach (var item in ccType)
                {
                    courseCategoryTypeService.newEntity(item);
                }
                classTypeService.newEntity(new ClassTypeDTO { ClassName = "ONline" });
                List<ClassTypeDTO> ctd = new List<ClassTypeDTO>();
                List<CourseDTO> courseDTOs = new List<CourseDTO>()
                {
                    new CourseDTO{CourseName="Access Bars",CourseCategoryTypeId=1,CustomerId=1 , ClassTypeDTOs = new List<ClassTypeDTO> { classTypeService.getAll()[0] }},
                    new CourseDTO{CourseName="Reiki",CourseCategoryTypeId=1,CustomerId=1, ClassTypeDTOs = new List<ClassTypeDTO> { classTypeService.getAll()[0] }},
                    new CourseDTO{CourseName="Reiki Çalışması",CourseCategoryTypeId=2,CustomerId=1, ClassTypeDTOs = new List<ClassTypeDTO> { classTypeService.getAll()[0] }},
                    new CourseDTO{CourseName="Birebir",CourseCategoryTypeId=3,CustomerId=1, ClassTypeDTOs = new List<ClassTypeDTO> { classTypeService.getAll()[0] }},
                    new CourseDTO{CourseName="İnsan Olma",CourseCategoryTypeId=2,CustomerId=1, ClassTypeDTOs = new List<ClassTypeDTO> { classTypeService.getAll()[0] }},
                    new CourseDTO{CourseName="Numeroloji",CourseCategoryTypeId=1,CustomerId=1, ClassTypeDTOs = new List<ClassTypeDTO> { classTypeService.getAll()[0] }},
                    new CourseDTO{CourseName="Çakra",CourseCategoryTypeId=1,CustomerId=1, ClassTypeDTOs = new List<ClassTypeDTO> { classTypeService.getAll()[0] }},
                };
                foreach (var item in courseDTOs)
                {
                    courseService.newEntity(item);
                }
            }
        }
    }
}
