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
    public class ProfileController : Controller
    {
        IUserPost Pos;
        IUserProfile Prof;
        IUserUpload Upl;
        IUserComment Com;




        public ProfileController(IUserProfile userprof, IUserPost userpost, IUserUpload upl, IUserComment com)
        {
            this.Prof = userprof;
            this.Pos = userpost;
            this.Upl = upl;
            this.Com = com;            
        }

        

        public IActionResult AllProfiles()
        {
            return View(Prof.GetProfile());
        }


        public IActionResult OtherUserProfilePage(string? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var viewModel = new UserProfileandPosts(Pos.GetPostsByUserId(id), Upl.GetUploadsByUserId(id), Com.GetCommentByUser(id), Prof.GetProfileByUserId(id));
                return View(viewModel);
            } else
            {
                return RedirectToAction("Index", "Home");
            }                        
        }


        [Authorize(Roles = "Admin,User")]
        public IActionResult UserProfilePage()
        {
            if (User.Identity.IsAuthenticated)
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
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public IActionResult AddProfile()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            else 
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public IActionResult AddProfile(Profile prof)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    prof.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Prof.AddProfile(prof);
                    return RedirectToAction("UserProfilePage", "Profile");
                }
                return View();
            } else
            {
                return RedirectToAction("Index", "Home");
            }
            
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
        [Authorize(Roles = "Admin,User")]
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
