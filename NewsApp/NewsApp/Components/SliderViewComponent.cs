using EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using NewsApp.Models;
using ServiceLayer.Contracts;

namespace NewsApp.Components
{
    public class SliderViewComponent : ViewComponent
    {



        private readonly IServiceManager _serviceManager;

        public SliderViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke()
        {
            var newsList = _serviceManager.NewsService.GetSliderNews();
            var viewModelList = new List<NewsViewModel>();
            ViewBag.categories = _serviceManager.CategoryService.GetAllCategories(false).ToList();
            foreach (var news in newsList)
            {

                var viewModel = new NewsViewModel
                {
                    NewsID = news.NewsID,
                    NewsTitle = news.NewsTitle,
                    NewsPhoto = news.NewsPhoto,
                    NewsShortDescription = news.NewsShortDescription,
                    NewsDate = news.NewsDate,
                    CategoryName = news.CategoryID.ToString()
                };

                viewModelList.Add(viewModel);
            }

            return View(viewModelList);
        }
    }
    
}
