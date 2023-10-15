using Microsoft.AspNetCore.Mvc;

namespace Artbase.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
