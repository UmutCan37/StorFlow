using Microsoft.AspNetCore.Mvc;

namespace StorFlow.ViewComponents
{
    public class _LayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
