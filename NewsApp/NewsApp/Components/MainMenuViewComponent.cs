using Microsoft.AspNetCore.Mvc;
using NewsApp.Areas.Admin.Models;
using NewsApp.Models;
using ServiceLayer.Contracts;

namespace NewsApp.Components
{
    public class MainMenuViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public MainMenuViewComponent(IServiceManager serviceManager)
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
