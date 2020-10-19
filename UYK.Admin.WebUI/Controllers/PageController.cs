using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UYK.BLL.Services.Abstract;
using UYK.DTO;

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

        public IActionResult AboutList()
        {
            List<AboutDTO> modelList = new List<AboutDTO>();
            modelList = aboutService.getAll();
            return View(modelList);
        }

        public IActionResult AboutAdd()
        {
            if (aboutService.getAll() == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("AboutUpdate");
            }
            
        }
        [HttpPost]
        public  IActionResult AboutAdd(AboutDTO aboutDTO)
        {
            aboutService.newEntity(aboutDTO);
            return RedirectToAction("AboutList");
        }
        public IActionResult AboutUpdate(AboutDTO aboutDTO)
        {
            
            var model = aboutService.getAll();
            return View(model);
        }
    }
}
