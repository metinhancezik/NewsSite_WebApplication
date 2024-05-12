using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace NewsApp.Components
{
    public class BreakingNewsViewComponent : ViewComponent
    {

        private readonly IServiceManager _serviceManager;

        public BreakingNewsViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke()
        {
            var newsList = _serviceManager.NewsService.GetBreakingtNews();
            return View("BreakingNews", newsList);
        }
    }
}
