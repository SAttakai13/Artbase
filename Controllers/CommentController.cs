using Microsoft.AspNetCore.Mvc;

namespace Artbase.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
