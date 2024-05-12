using EntityLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace NewsApp.Areas.Admin.Controllers
{
    [Area("Admin")]
     [Authorize(Policy = "AdminOnly")]
    public class AuthorController : Controller
    {
        private readonly IServiceManager _manager;

        public AuthorController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.AuthorService.GetAllAuthor(false);
            return View(model);
        }
        public IActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult YazarEkle(Author author)
        {
            if(ModelState.IsValid)
            {
                _manager.AuthorService.CreateAuthor(author);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult YazarSil(int id)
        {
            _manager.AuthorService.DeleteAuthor(id);
            return RedirectToAction("Index");
        }

        public IActionResult YazarGuncelle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult YazarGuncelle(Author author)
        {
            if(ModelState.IsValid)
            {
                _manager.AuthorService.UpdateAuthor(author);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
