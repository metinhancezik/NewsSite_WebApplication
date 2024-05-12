using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NewsApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "AdminOnly")]
    public class KullanimSartlariController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
