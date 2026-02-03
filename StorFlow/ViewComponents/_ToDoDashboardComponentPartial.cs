using Microsoft.AspNetCore.Mvc;
using StorFlow.Context;

namespace StorFlow.ViewComponents
{
    public class _ToDoDashboardComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;

        public _ToDoDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.ToDos.OrderByDescending(z => z.TodoId).Take(6).ToList();
            return View(values);
        }
    
    }
}
