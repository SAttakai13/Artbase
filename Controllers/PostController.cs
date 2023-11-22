using Artbase.Data;
using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Artbase.Controllers
{
    public class PostController : Controller
    {
        IUserPost Pos;
        IUserProfile Prof;
        IUserUpload Upl;

        public PostController(IUserPost pos, IUserProfile prof, IUserUpload upl)
        {
            this.Pos = pos;
            this.Prof = prof;
            this.Upl = upl;
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
        public IActionResult EditPost(int id)
        {
            Post postFound = Pos.GetPostById(id);
            return View(postFound);
        }

        [HttpPost]
        public IActionResult EditPost(Post post)
        {
            if (ModelState.IsValid)
            {
                post.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Pos.EditPost(post);
                return RedirectToAction("UserProfilePage", "Profile");
            }
            return View();
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

        public IActionResult ViewAllPosts()
        {
            var postsanduploads = new UserProfileandPosts(Pos.GetPosts(), Upl.GetUploads());
            return View(postsanduploads);
        }
    }
}
