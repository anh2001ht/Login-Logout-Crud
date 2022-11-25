using Microsoft.AspNetCore.Mvc;
using MyCode_EntityFramework.Models;
using System.Diagnostics;




namespace MyCode_EntityFramework.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataUserContext _context;

        private readonly ILogger<HomeController> _logger;

        private DB_Entities _db = new DB_Entities();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        /*{
            if (username == "ha1" && password == "123")
            {
                HttpContext.Session.SetString("username", "username");
                //return View("Success");
                return RedirectToAction("Index", "Usertbls");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }*/

        {
            using (DB_Entities db = new DB_Entities())
            {
                var userDetail = db.user.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
                string name = username;
                HttpContext.Session.SetString("UserID", name);
                if (userDetail != null)
                {
                    return RedirectToAction("Index", "Usertbls");
                }
                else
                {
                    ViewBag.error = "Invalid Account";
                    return View("Index");
                }

            }
        }
        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}