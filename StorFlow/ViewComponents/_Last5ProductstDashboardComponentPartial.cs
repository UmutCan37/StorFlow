using Microsoft.AspNetCore.Mvc;
using StorFlow.Context;

namespace StorFlow.ViewComponents
{
    public class _Last5ProductstDashboardComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;

        public _Last5ProductstDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Products.OrderBy(x => x.ProductId).ToList().SkipLast(5).ToList().TakeLast(5).ToList();
            return View(values);
        }
    
    }
}
