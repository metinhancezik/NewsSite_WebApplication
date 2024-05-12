using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace NewsApp.Components
{
    public class AnaHaberViewComponent : ViewComponent
    {

        private readonly IServiceManager _serviceManager;

        public AnaHaberViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public IViewComponentResult Invoke()
        {
            var model = _serviceManager.NewsService.GetAnaHaberNews();
            return View("AnaHaber",model);
        }
    }
}
