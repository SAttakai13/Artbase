using Artbase.Data;
using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Security.Claims;

namespace Artbase.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class ProfileController : Controller
    {
        IUserPost Pos;
        IUserProfile Prof;
        IUserUpload Upl;
        IUserComment Com;
        ISaveUploadToUser Save;



        public ProfileController(IUserProfile userprof, IUserPost userpost, IUserUpload upl, IUserComment com, ISaveUploadToUser save)
        {
            this.Prof = userprof;
            this.Pos = userpost;
            this.Upl = upl;
            this.Com = com;
            this.Save = save;
        }


        [AllowAnonymous]
        public IActionResult AllProfiles()
        {
            return View(Prof.GetProfile());
        }

        [AllowAnonymous]
        //User Saves are right here
        public IActionResult OtherUserProfilePage(string? id)
        {
            var viewModel = new UserProfileandPosts(Pos.GetPostsByUserId(id), Upl.GetUploadsByUserId(id), Com.GetCommentByUser(id), Prof.GetProfileByUserId(id), Save.GetAllSavedUploads());
            return View(viewModel);
        }

        public IActionResult UserProfilePage()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var viewModel = new UserProfileandPosts(Pos.GetPostsByUserId(userid), Upl.GetUploadsByUserId(userid), Com.GetCommentByUser(userid), Prof.GetProfileByUserId(userid));
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
        public IActionResult EditProfile(int? id)
        {
            
            if (id == null)
            {
                ViewData["Error"] = "Bad Profile Id";
                return View();
            }
            else
            {
                Profile proFound = Prof.GetProfileById(id);
                if (proFound == null)
                {
                    ViewData["Error"] = "Profile not found. Create one?";
                }
                return View(proFound);
            }
            
        }

        [HttpPost]
        public IActionResult EditProfile(Profile prof)
        {
            
            prof.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Profile modprofile = prof;
            if (ModelState.IsValid)
            {                
                Prof.EditProfile(modprofile);
                return RedirectToAction("UserProfilePage", "Profile");
            } else
            {
                return View();
            }                
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult SearchUser(string user)
        {
            if (string.IsNullOrEmpty(user))
            {
                return View("AllProfiles", Prof.GetProfile());
            }

            return View("AllProfiles", Prof.FilterProfiles(user));
        }

    }
}
