using Microsoft.AspNetCore.Mvc;

namespace StorFlow.ViewComponents
{
    public class _RightSidebarDashboardComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
