using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace NewsApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminOnly")]
    public class DefaultController : Controller
    {
            private readonly IServiceManager _serviceManager;
            public DefaultController(IServiceManager serviceManager)
            {
                _serviceManager = serviceManager;
            }
            public IActionResult Index()
        {

            int mevcutHaberSayisi = _serviceManager.NewsService.GetAllNews(false).Count();

            ViewBag.countNews=mevcutHaberSayisi;
            return View();
        }
    }
}
