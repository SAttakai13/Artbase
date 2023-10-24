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

        //[HttpGet]
        //public IActionResult AllProfiles()
        //{
            
        //}

        //[HttpGet]
        //public IActionResult OtherUserProfilePage(string? userId)
        //{
            
        //}


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

        //[HttpPost]
        //public IActionResult AddProfile(Profile prof)
        //{
            
        //}


    }
}
