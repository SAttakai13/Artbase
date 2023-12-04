using Artbase.Data;
using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Policy;

namespace Artbase.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class UploadController : Controller
    {
        IUserUpload Up;
        IUserPost Pos;
        ISaveUploadToUser SaveUp;

        public UploadController(IUserUpload up, IUserPost pos, ISaveUploadToUser saveup)
        {
            this.Up = up;
            this.Pos = pos;
            this.SaveUp = saveup;
        }

        public IEnumerable<Upload> SavedUploadsForUser(string? userId)
        {
            IEnumerable<SaveUploadToUser> lstofSaved = SaveUp.GetAllSavedUploads().Where(p => p.UserId == userId).ToList();
            IEnumerable<Upload> savedUploads = new List<Upload>();


            if (lstofSaved.Count() == 0)
                return null;

            foreach (SaveUploadToUser save in lstofSaved)
            {
                Upload upload = Up.GetUploadById(save.UploadId);
                savedUploads.Append(upload);
            }

            if (savedUploads.Count() == 0)
                return null;

            return savedUploads;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddUpload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUpload(FileUpload filemod)
        {
            if (filemod.File != null && filemod.File.Length > 0)
            {
                using (var filestream = filemod.File.OpenReadStream())
                using (var memoryStream = new MemoryStream())
                {
                    filestream.CopyTo(memoryStream);
                    var fileContentBytes = memoryStream.ToArray();

                    var fileModel = new Upload
                    {
                        fileTypes = filemod.File.ContentType,
                        fileUrl = filemod.File.FileName,
                        fileContent = fileContentBytes,
                        UserID = User.FindFirstValue(ClaimTypes.NameIdentifier)
                    };
                    if (ModelState.IsValid)
                    {
                        Up.AddUpload(fileModel);
                        Ok();
                        return RedirectToAction("UserProfilePage", "Profile");
                    }                    
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteUpload(int? id)
        {
            
            if (Up.GetUploadById(id) == null)
            {
                ModelState.AddModelError("UploadId", "Upload not found");
            }

            if (ModelState.IsValid)
            {
                Up.DeleteUpload(id);
            }

            return RedirectToAction("UserProfilePage", "Profile");
        }


        //Still need to read from the database
        
        public IActionResult ViewAllUploads()
        {
            string user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var postsanduploads = new UserProfileandPosts(Pos.GetPostsByUserId(user), Up.GetUploadsByUserId(user), SavedUploadsForUser(user));
            return View(postsanduploads);
        }        

    }
}
