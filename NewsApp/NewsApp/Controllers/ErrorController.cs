using Microsoft.AspNetCore.Mvc;

namespace NewsApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}
