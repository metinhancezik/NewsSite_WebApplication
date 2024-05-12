using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NewsApp.Areas.Admin.Controllers
{
    public class GizlilikPolitikasiController : Controller
    {
        [Area("Admin")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
