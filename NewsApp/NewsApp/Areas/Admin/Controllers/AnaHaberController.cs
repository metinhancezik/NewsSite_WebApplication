using EntityLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace NewsApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminOnly")]
    public class AnaHaberController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public AnaHaberController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public IActionResult Index()
        {
            var news = _serviceManager.NewsService.GetAllNews(false);
            return View(news);
        }

        [HttpPost]
        public IActionResult UpdateAnaHaber(int newsId, bool AnaHaber)
        {


            var newsToUpdate = _serviceManager.NewsService.GetOneNews(newsId, false);
            if (newsToUpdate != null)
            {
                newsToUpdate.AnaHaber = AnaHaber;
                _serviceManager.NewsService.UpdateNews(newsToUpdate);
            }

            return Json(new { success = false, message = "Haber bulunamadı." });
        }

    }
}
