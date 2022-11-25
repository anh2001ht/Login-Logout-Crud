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
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}