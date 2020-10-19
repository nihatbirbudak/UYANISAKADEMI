using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
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
        public LoginController(ICustomerService _customerService, IRoleService _roleService)
        {
            customerService = _customerService;
            roleService = _roleService;
        }
        
        public ActionResult UserLogin()
        {
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
                       new Claim("UserDTO",UYKConvert.UYKJsonSerialize(user))
                };
                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                HttpContext.SignInAsync(userPrincipal);
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
    }
}
