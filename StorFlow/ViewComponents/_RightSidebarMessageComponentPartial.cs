using Microsoft.AspNetCore.Mvc;
using StorFlow.Context;

namespace StorFlow.ViewComponents
{
    public class _RightSidebarMessageComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;

        public _RightSidebarMessageComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Messages.ToList();
            return View(values);
        }
    
    }
}
