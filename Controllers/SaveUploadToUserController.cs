using Artbase.Data;
using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Artbase.Controllers
{
    public class SaveUploadToUserController : Controller
    {
        ISaveUploadToUser saveUp;
        public SaveUploadToUserController(ISaveUploadToUser saveUp)
        {
            this.saveUp = saveUp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public void CheckIfInDataBase(int? uploadid, string? userid)
        {
            
            if(saveUp.GetSaveUploadByUserAndId(userid, uploadid) != null)
            {
                TempData["InDatabase"] = "True";
            }
            else
            {
                TempData["InDatabase"] = "False";
            }
        }

        [HttpGet]

        public IActionResult SaveUpload(int? id)
        {
            string currentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            SaveUploadToUser usersave = new SaveUploadToUser(id, currentUser);
            if(ModelState.IsValid)
            {
                saveUp.SaveUpload(usersave);
                CheckIfInDataBase(id, currentUser);
                Trace.WriteLine("Posted");
                
            }
            return RedirectToAction("UserProfilePage", "Profile");
        }

        [HttpGet]
        public IActionResult RemoveSavedUpload(int? id)
        {
            if(saveUp.GetSavedUploadById(id) == null)
            {
                ModelState.AddModelError("UploadId", "Saved upload not found");
            }

            if (ModelState.IsValid)
            {
                saveUp.DeleteSavedUpload(id);
            }

            return RedirectToAction("UserProfilePage", "Profile");
        }
    }
}
