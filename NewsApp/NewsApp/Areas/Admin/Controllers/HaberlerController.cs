using Entities.RequestParameters;
using EntityLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewsApp.Models;
using Newtonsoft.Json;
using ServiceLayer;
using ServiceLayer.Contracts;
using StoreApp.Models;
using System.Security.Policy;

namespace NewsApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminOnly")]
    public class HaberlerController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public HaberlerController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_serviceManager.CategoryService.GetAllCategories(false), "CategoryID", "CategoryName", "1");
        }
        public IActionResult Index(NewsRequestParameters n)
        {
            //var news = _serviceManager.NewsService.GetAllNews(false);
            var news = _serviceManager.NewsService.GetAllNewsWithDetails(n);
            var pagination = new Pagination()
            {
                CurrenPage = n.PageNumber,
                ItemsPerPage = n.PageSize,
                TotalItems = _serviceManager.NewsService.GetAllNews(false).Count()
            };

            return View(new NewsListViewModel()
            { News = news, Pagination = pagination }
                );
        }


        public IActionResult HaberEkle()
        {
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HaberEkle([FromForm] News news, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //file Op
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                news.NewsPhoto = String.Concat("/images/", file.FileName);
                _serviceManager.NewsService.CreateNews(news);
                return RedirectToAction("Index");
            }



            ViewBag.Categories = GetCategoriesSelectList();

            return View();
        }
        [HttpGet]
        public IActionResult HaberDuzenle(int id)
        {

            ViewBag.ID = id;
            ViewBag.Categories = GetCategoriesSelectList();
            var existingNews = _serviceManager.NewsService.GetOneNews(id, false);

            if (existingNews == null)
            {

                return NotFound();
            }

            return View(existingNews);
        }


        [HttpPost]
        public async Task<IActionResult> HaberDuzenleAsync(News model, IFormFile? file, String oldPhoto)
        {
            if (ModelState.IsValid)
            {
                // Eğer yeni bir dosya seçilmediyse, mevcut fotoğrafın URL'sini kullanın
                if (file == null)
                {
                    model.NewsPhoto = oldPhoto;
                }
                else
                {

                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    model.NewsPhoto = String.Concat("/images/", file.FileName);
                }

                _serviceManager.NewsService.UpdateNews(model);

                return RedirectToAction("Index", "Haberler");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult FilterNews(string FilterNews)
        {
            var filterAra = FilterNews.ToLower();
            var news = _serviceManager.NewsService.GetAllNews(false);
            var newsValue = news.Where(s => s.NewsTitle.ToLower().Contains(filterAra));
            var sitesValue2 = JsonConvert.SerializeObject(newsValue);
            return new JsonResult(sitesValue2);
        }
        public IActionResult HaberSil(int id)
        {
            _serviceManager.NewsService.DeleteNews(id);
            return RedirectToAction("Index");
        }

    }

}

