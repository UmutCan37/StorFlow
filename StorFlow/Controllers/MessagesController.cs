using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorFlow.Context;

namespace StorFlow.Controllers
{
    public class MessagesController : Controller
    {
        private readonly StoreContext _context;

        public MessagesController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult MessagesList()
        {
            var values = _context.Messages.AsNoTracking().ToList();
            return View(values);
        }
    }
}
