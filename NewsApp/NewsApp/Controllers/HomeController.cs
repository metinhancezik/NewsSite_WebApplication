using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsApp.Models;
using ServiceLayer.Contracts;
using System.Diagnostics;

namespace NewsApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public HomeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Categories()
        {
            return View();
        }
        public IActionResult NewsDetails(int id)
        {
            var news = _serviceManager.NewsService.GetAllNews(false).SingleOrDefault(x => x.NewsID == id);

            if (news == null)
            {             
                return RedirectToAction("Error"); 
            }

            return View(news);
        }
    }
}