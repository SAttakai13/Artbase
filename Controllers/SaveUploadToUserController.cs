using Artbase.Data;
using Artbase.Interfaces;
using Artbase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpPost]
        public IActionResult SavePost(int? id)
        {
            string currentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            SaveUploadToUser usersave = new SaveUploadToUser(id, currentUser);
            if(ModelState.IsValid)
            {
                saveUp.SaveUpload(usersave);
                return RedirectToAction("UserProfilePage", "Profile");
            }
            return View("Index", "Home");
        }



    }
}
