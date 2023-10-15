using Microsoft.AspNetCore.Mvc;

namespace Artbase.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
