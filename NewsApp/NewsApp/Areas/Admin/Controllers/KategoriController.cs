using EntityLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace NewsApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminOnly")]
    public class KategoriController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public KategoriController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var categories = _serviceManager.CategoryService.GetAllCategories(false);
            
           
            return View(categories);
        }
        public IActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult KategoriEkle([FromForm]Category category)
        {
            _serviceManager.CategoryService.CreateCategory(category);
            return RedirectToAction("Index");
        }
    }
}
