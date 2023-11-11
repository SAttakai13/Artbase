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
                        fileType = filemod.File.ContentType,
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

        //Still need to read from the database
        public IActionResult ViewAllUploads()
        {
            //IEnumerable<Upload> files = Up.GetUploads();
            //var result = new List<File>();

            //foreach (Upload file in files)
            //{
            //    if (files != null)
            //    {
            //        var save = File(file.fileContent, file.fileType);
            //        result.Add(save);
            //    }
            //}
            return View(Up.GetUploads());
        }

    }
}
