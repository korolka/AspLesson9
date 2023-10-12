using AspLesson9.Infrastructure;
using AspLesson9.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspLesson9.Controllers
{
    //[ActionUserCount]
    //[ServiceFilter(typeof(ActionInfoAttribute))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Index3()
        {
            return View();
        }
    }
}
