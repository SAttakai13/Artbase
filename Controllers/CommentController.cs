using Artbase.Data;
using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace Artbase.Controllers
{
    public class CommentController : Controller
    {

        IUserPost Pos;
        IUserProfile Prof;
        IUserComment Comm;

        public CommentController(IUserPost pos, IUserProfile prof, IUserComment comm)
        {
            this.Pos = pos;
            this.Prof = prof;
            this.Comm = comm;
        }

        [HttpPost]
        public IActionResult AddComment(UserProfileandPosts user, int? id)
        {
            var comment = new Comment
            {
                message = user.UserComment.message,
                UserCommentID = User.FindFirstValue(ClaimTypes.NameIdentifier),
                PostID = id
            };

            if (ModelState.IsValid)
            {
                Comm.AddComment(comment);
                return RedirectToAction("Profile/UserProfilePage/#"+id);
            }
            return View();
        }

        //[HttpGet]
        //public IActionResult EditComment(int id)
        //{
            
        //}
        //[HttpPost]
        //public IActionResult EditComment(Comment comment) 
        //{

        //}

        [HttpGet]
        public IActionResult DeleteComment(int? id)
        {
            if (Comm.GetCommentById(id) == null)
            {
                ModelState.AddModelError("CommentId", "Comment not found");
            }
            if (ModelState.IsValid)
            {
                Comm.DeleteComment(id);
            }
            return RedirectToAction("Index", "Home");
        }


        
        public IActionResult ViewAllCommentsUnderPost(int? id)
        {
            return View(Comm.GetAllCommentsByPost(id));
        }


    }
}
