using Microsoft.AspNetCore.Mvc;
using MyCode_EntityFramework.Models;

namespace MyCode_EntityFramework.Controllers
{
    public class LoginController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Autherize(MyCode_EntityFramework.Models.Usertbl userModel)
        {
            using (DB_Entities db = new DB_Entities())
            {
                var userDetail = db.user.Where(x => x.UserName == userModel.UserName&&x.Password==userModel.Password).FirstOrDefault();
                string name = userModel.UserName;
                HttpContext.Session.SetString("UserID", name);
                if (userDetail==null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Usertbls");
                }
              
            }

           
        }
    }
}
