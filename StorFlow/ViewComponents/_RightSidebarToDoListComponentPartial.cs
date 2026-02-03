using Microsoft.AspNetCore.Mvc;
using StorFlow.Context;

namespace StorFlow.ViewComponents
{
    public class _RightSidebarToDoListComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;

        public _RightSidebarToDoListComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.ToDos.ToList();
            return View(values);
        }
    
    }
}
