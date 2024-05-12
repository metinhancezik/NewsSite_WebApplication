using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using NewsApp.Models;
using ServiceLayer.Contracts;
using System.Collections.Generic;

namespace NewsApp.Components
{
    public class CategoriesOrtaSayfaViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public CategoriesOrtaSayfaViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke()
        {

            var model = new CategoriesOrtaSayfaModel();

            
            model.Categories = _serviceManager.CategoryService.GetAllCategories(false).ToList();

           
            foreach (var category in model.Categories)
            {
                var newsByCategory = _serviceManager.NewsService.GetAllNewsByCategory(category.CategoryID);

                if (newsByCategory.Any())
                {
                    model.NewsByCategory.Add(category, newsByCategory.ToList());
                }
            }

            return View("Default", model);
        }



    }
}
