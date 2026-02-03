using Microsoft.AspNetCore.Mvc;

namespace StorFlow.ViewComponents
{
    public class _ThemeSettingsWrapperDashboardComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
