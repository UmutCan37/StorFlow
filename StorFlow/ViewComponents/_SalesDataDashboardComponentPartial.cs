using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorFlow.Context;

namespace StorFlow.ViewComponents
{
    public class _SalesDataDashboardComponentPartial : ViewComponent
    {
        private readonly StoreContext _storeContext;

        public _SalesDataDashboardComponentPartial(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IViewComponentResult Invoke()
        {
            var values = _storeContext.Orders.OrderByDescending(z=>z.OrderId).Include(x => x.Customer).Include(y=>y.Product).Take(5).ToList();
            return View(values);
        }
    }
}
