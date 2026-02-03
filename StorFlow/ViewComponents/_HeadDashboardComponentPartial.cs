using Microsoft.AspNetCore.Mvc;

namespace StorFlow.ViewComponents
{
    public class _HeadDashboardComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
