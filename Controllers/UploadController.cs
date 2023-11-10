using Artbase.Data;
using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace Artbase.Controllers
{
    public class UploadController : Controller
    {
        IUserUpload Up;

        public UploadController(IUserUpload up)
        {
            Up = up;
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
        public IActionResult AddUpload(IFormFile file)
        {
            //objs.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //dal.AddUpload(objs);
            //Ok();
            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    var fileModel = new Upload
                    {
                        fileUrl = file.FileName,
                        fileContent = memoryStream.ToArray(),
                        UserID = User.FindFirstValue(ClaimTypes.NameIdentifier)
                    };

                    Up.AddUpload(fileModel);
                    return RedirectToAction("UserProfilePage", "Profile");
                }
            }
            return View();
        }
    }
}
