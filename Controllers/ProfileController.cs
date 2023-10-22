using Artbase.Data;
using Artbase.Models;
using Microsoft.AspNetCore.Mvc;

namespace Artbase.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserProfileDAL _profileService;
        
        public ProfileController(UserProfileDAL profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<IActionResult> AllProfiles()
        {
            return View(await _profileService.GetProfile());
        }

        [HttpGet]
        public async Task<ActionResult> OtherUserProfilePage(string? userId)
        {
            var profile = await _profileService.GetProfileByUserId(userId);
            
            if (profile is null)
            {
                return NotFound();
            }
            return View(profile);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserProfilePage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddProfile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProfile(Profile prof)
        {
            return RedirectToAction("Index", "Home");
        }


    }
}
