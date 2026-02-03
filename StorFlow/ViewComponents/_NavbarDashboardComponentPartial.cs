using Microsoft.AspNetCore.Mvc;

namespace StorFlow.ViewComponents
{
    public class _NavbarDashboardComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
