using Artbase.Data;
using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Artbase.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class PostController : Controller
    {
        IUserPost Pos;
        IUserProfile Prof;
        IUserUpload Upl;
        ISaveUploadToUser Save;


        public PostController(IUserPost pos, IUserProfile prof, IUserUpload upl, ISaveUploadToUser save)
        {
            this.Pos = pos;
            this.Prof = prof;
            this.Upl = upl;
            this.Save = save;
        }

        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPost(Post post)
        {            
            if (ModelState.IsValid)
            {
                post.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Pos.CreatePost(post);
                return RedirectToAction("UserProfilePage", "Profile");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditPost(int? id)
        {
            if (id == null)
            {
                ViewData["Error"] = "Bad Post";
                return View();
            } else
            {
                Post postFound = Pos.GetPostById(id);
                if (postFound == null)
                {
                    ViewData["Error"] = "Post not found";
                }
                return View(postFound);
            }            
        }

        [HttpPost]
        public IActionResult EditPost(Post post)
        {
            post.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Post modpost = post;
            if (ModelState.IsValid)
            {                
                Pos.EditPost(modpost);
                return RedirectToAction("UserProfilePage", "Profile");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult DeletePost(int? id)
        {
            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (Pos.GetPostById(id) == null)
            {
                ModelState.AddModelError("PostID", "Post not found");
            }

            if (ModelState.IsValid)
            {
                Pos.DeletePost(id);
            }

            return RedirectToAction("UserProfilePage", "Profile");
        }

        [AllowAnonymous]
        //Dashboard
        //User Saves are right here
        public IActionResult ViewAllPosts()
        {
            var postsanduploads = new UserProfileandPosts(Pos.GetPosts(), Upl.GetUploads(), Save.GetAllSavedUploads());
            return View(postsanduploads);
        }
    }
}
