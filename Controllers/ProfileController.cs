using Artbase.Data;
using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Artbase.Controllers
{
    public class ProfileController : Controller
    {
        IUserPost Pos;
        IUserProfile Prof;
        
        public ProfileController(IUserProfile userprof, IUserPost userpost)
        {
            Prof = userprof;
            Pos = userpost;
        }

        public IActionResult AllProfiles()
        {
            return View(Prof.GetProfile());
        }


        public IActionResult OtherUserProfilePage(string? userId)
        {
            var viewModel = new UserProfileandPosts(Pos.GetPosts().Where(m => m.UserId == userId).ToList(), Prof.SearchProfileByUserId(userId));

            return View(viewModel);
        }
        public IActionResult UserProfilePage()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var viewModel = new UserProfileandPosts(Pos.GetPosts().Where(m => m.UserId == userid).ToList(), Prof.SearchProfileByUserId(userid));

            try
            {
                if (viewModel.UserProfile != null)
                {
                    return View(viewModel);
                }
                else if (viewModel.UserProfile == null)
                {
                    return RedirectToAction("AddProfile", "Profile");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProfile(Profile prof)
        {
            if (ModelState.IsValid)
            {
                prof.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Prof.AddProfile(prof);
                return RedirectToAction("UserProfilePage", "Profile");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditProfile(int id)
        {
            Profile proFound = Prof.GetProfileById(id);
            if (proFound == null)
            {
                ViewData["Error"] = "Profile not found. Create one?";
            }
            return View(proFound);
        }

        [HttpPost]
        public IActionResult EditProfile(Profile prof)
        {
            if (ModelState.IsValid)
            {
                prof.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Prof.EditProfile(prof);
                return RedirectToAction("UserProfilePage", "Profile");
            }
            return View();
        }

    }
}
