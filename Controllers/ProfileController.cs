using Microsoft.AspNetCore.Mvc;

namespace Artbase.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserProfilePage()
        {
            return View();
        }

    }
}
