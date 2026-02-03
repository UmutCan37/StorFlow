using Microsoft.AspNetCore.Mvc;

namespace StorFlow.ViewComponents
{
    public class _LayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
