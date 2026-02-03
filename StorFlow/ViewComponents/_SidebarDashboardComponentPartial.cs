using Microsoft.AspNetCore.Mvc;

namespace StorFlow.ViewComponents
{
    public class _SidebarDashboardComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
