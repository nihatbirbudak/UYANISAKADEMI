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
        private readonly ISupplierService supplierService;
        private readonly IActivityService activityService;
        private readonly IProductService productService;
        public LoginController(IProductService productService, IActivityService activityService, ICustomerService _customerService, IRoleService _roleService, ICourseService courseService, ICourseCategoryTypeService courseCategoryTypeService, IClassTypeService classTypeService, ISupplierService supplierService)
        {
            customerService = _customerService;
            roleService = _roleService;
            this.courseService = courseService;
            this.courseCategoryTypeService = courseCategoryTypeService;
            this.classTypeService = classTypeService;
            this.supplierService = supplierService;
            this.activityService = activityService;
            this.productService = productService;
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
                HttpContext.SignInAsync(userPrincipal, userProps);
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
            if (roleService.getAll().Count() == 0)
            {
                List<RoleDTO> roles = new List<RoleDTO>()
            {
                new RoleDTO { RoleName = "Admin"},
                new RoleDTO { RoleName = "Instructor"},
                new RoleDTO { RoleName = "User"}
            };
                foreach (var item in roles)
                {
                    roleService.newEntity(item);
                }
            }
            if (customerService.getAll().Count() == 0)
            {
                var customers = new List<CustomerDTO>()
            {
                new CustomerDTO {
                    FirstName = "Nihat",
                    LastName = "Birbudak",
                    Email = "nihat@mail.com",
                    Password = "1234",
                    UserName = "nbirbudak",
                    RoleId = (int)roleService.getAll()[0].ID
                },
                new CustomerDTO
                {
                    FirstName = "Emine",
                    LastName = "Birbudak",
                    Email = "emine@mail.com",
                    Password = "1234",
                    UserName = "ebirbudak",
                    RoleId = (int)roleService.getAll()[1].ID
                },
                new CustomerDTO
                {
                    FirstName = "Arzu",
                    LastName = "Ürkmez",
                    Email = "arzu@mail.com",
                    Password = "1234",
                    UserName = "Arzuürkmez",
                    RoleId = (int)roleService.getAll()[1].ID
                },
                new CustomerDTO
                {
                    FirstName = "Beril",
                    LastName = "Birbudak",
                    Email = "berik@mail.com",
                    Password = "1234",
                    UserName = "bbirbudak",
                    RoleId = (int)roleService.getAll()[2].ID
                },
            };
                foreach (var item in customers)
                {
                    customerService.newEntity(item);
                }
            }
            if (supplierService.getAll().Count() == 0)
            {
                var sup = new SupplierDTO()
                {
                    CustomerId = 2,
                    City = "İzmir",
                    CompanyName = "Uyanış Akademi",
                    Address1 = "Pamukkale Evleri Mavişehir",
                    Country = "Türkiye",
                };
                supplierService.newEntity(sup);
            }
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
                classTypeService.newEntity(new ClassTypeDTO { ClassName = "Online" });
                classTypeService.newEntity(new ClassTypeDTO { ClassName = "Yüz Yüze" });
                List<ClassTypeDTO> ctd = new List<ClassTypeDTO>();
                List<CourseDTO> courseDTOs = new List<CourseDTO>()
                {
                    new CourseDTO{CourseName="Access Bars",CourseCategoryTypeId=1, ClassTypeDTOs = new List<ClassTypeDTO> { classTypeService.getAll()[0] }},
                    new CourseDTO{CourseName="Reiki",CourseCategoryTypeId=1, ClassTypeDTOs = new List<ClassTypeDTO> { classTypeService.getAll()[0] }},
                    new CourseDTO{CourseName="Reiki Çalışması",CourseCategoryTypeId=2, ClassTypeDTOs = new List<ClassTypeDTO> { classTypeService.getAll()[0] }},
                    new CourseDTO{CourseName="Birebir",CourseCategoryTypeId=3, ClassTypeDTOs = new List<ClassTypeDTO> { classTypeService.getAll()[0] }},
                    new CourseDTO{CourseName="İnsan Olma",CourseCategoryTypeId=2, ClassTypeDTOs = new List<ClassTypeDTO> { classTypeService.getAll()[0] }},
                    new CourseDTO{CourseName="Numeroloji",CourseCategoryTypeId=1, ClassTypeDTOs = new List<ClassTypeDTO> { classTypeService.getAll()[0] }},
                    new CourseDTO{CourseName="Çakra",CourseCategoryTypeId=1, ClassTypeDTOs = new List<ClassTypeDTO> { classTypeService.getAll()[0] }},
                };
                foreach (var item in courseDTOs)
                {
                    courseService.newEntity(item);
                }
            }
            if (activityService.getAll().Count() == 0)
            {
                var activitys = new List<ActivityDTO>()
                {
                    new ActivityDTO
                    {
                        Tags = "Naber",
                        CourseId = 1,
                        CustomerId = 2,
                    }
                };
                activityService.newEntity(activitys[0]);
            }
            if (productService.getAll().Count() == 0)
            {
                var products = new List<ProductDTO>()
                {
                    new ProductDTO
                    {
                        ProductName = "deneme inş",
                        
                    }
                };
                productService.newEntity(products[0]);
            }
        }
    }
}
