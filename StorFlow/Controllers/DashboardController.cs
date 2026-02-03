using Microsoft.AspNetCore.Mvc;

namespace StorFlow.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Statistics()
        {
            return View();
        }
    }
}
