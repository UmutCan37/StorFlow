using Microsoft.AspNetCore.Mvc;
using StorFlow.Context;

namespace StorFlow.ViewComponents
{
    public class _LayoutTodoOnNavbarComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;

        public _LayoutTodoOnNavbarComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.ToDos.Where(x=>x.Status==false).OrderBy(x => x.TodoId).Take(5).ToList();
            ViewBag.todoTotalCount = _context.ToDos.Count();
            return View(values);
        }
    
    }
}
