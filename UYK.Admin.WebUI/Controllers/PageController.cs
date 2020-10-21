using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UYK.BLL.Services.Abstract;
using UYK.DTO;
using UYK.WebUI.Admin.Models;

namespace UYK.WebUI.Admin.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class PageController : BaseController
    {
        private IAboutService aboutService;
        public PageController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

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
        public  IActionResult AboutAdd(AboutDTO aboutDTO)
        {
            aboutDTO.CustomerId = CurrentUser.ID;
            aboutDTO.UpdateDate = DateTime.UtcNow;
            aboutService.newEntity(aboutDTO);
            return RedirectToAction("AboutUpdate");
        }
        public IActionResult AboutUpdate(AboutDTO aboutDTO)
        {
            var model = new AboutViewModel();
            model.CurrentUser = CurrentUser;
            model.AboutDTO = aboutService.getAll()[0];
            return View(model);
        }
    }
}
