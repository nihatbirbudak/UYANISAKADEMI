using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UYK.BLL.Services.Abstract;
using UYK.DTO;

namespace UYK.WebUI.Admin.Controllers
{
    public class PageController : Controller
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
            return View();
        }
        [HttpPost]
        public  IActionResult AboutAdd(AboutDTO aboutDTO)
        {
            aboutService.newEntity(aboutDTO);
            return RedirectToAction("AboutList");
        }
    }
}
