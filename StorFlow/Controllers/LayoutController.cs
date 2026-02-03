using Microsoft.AspNetCore.Mvc;

namespace StorFlow.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
