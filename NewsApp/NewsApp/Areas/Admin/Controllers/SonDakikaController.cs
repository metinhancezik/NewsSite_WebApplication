using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace NewsApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminOnly")]
    public class SonDakikaController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public SonDakikaController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public IActionResult Index()
        {
            var sonDakikaNews=_serviceManager.NewsService.GetAllNews(false);
            return View(sonDakikaNews);
        }
        [HttpPost]
        public IActionResult UpdateNewsInSlide(int newsId, bool newsInSlide) //We made the same method with Vitrin. 
        {


            var newsToUpdate = _serviceManager.NewsService.GetOneNews(newsId, false);
            if (newsToUpdate != null)
            {
                newsToUpdate.NewsIsLatest = newsInSlide;
                _serviceManager.NewsService.UpdateNews(newsToUpdate);
            }

            return Json(new { success = false, message = "Haber bulunamadı." });
        }

    }
}
