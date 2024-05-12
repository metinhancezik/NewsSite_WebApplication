using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace NewsApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminOnly")]
    public class VitrinController : Controller
    {

        private readonly IServiceManager _serviceManager;

        public VitrinController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        public IActionResult Index()
        {
            var news = _serviceManager.NewsService.GetAllNews(false);
            return View(news);
        }

        [HttpPost]
        public IActionResult UpdateNewsInSlide(int newsId, bool newsInSlide)
        {


            var newsToUpdate = _serviceManager.NewsService.GetOneNews(newsId, false);
            if (newsToUpdate != null)
            {
                newsToUpdate.NewsInSlide = newsInSlide; 
                _serviceManager.NewsService.UpdateNews(newsToUpdate);
            }

            return Json(new { success = false, message = "Haber bulunamadı." });
        }



    }
}
