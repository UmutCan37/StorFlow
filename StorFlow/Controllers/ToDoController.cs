using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorFlow.Context;
using StorFlow.Entities;

namespace StorFlow.Controllers
{
    public class ToDoController : Controller
    {
        private readonly StoreContext _storeContext;

        public ToDoController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateToDo()
        {
            var todos = new List<ToDo>
            {
                new ToDo { Description = "Mail gönder", Status = true, Priority = "Birincil" },
                new ToDo { Description = "Rapor hazırla", Status = true, Priority = "İkincil" },
                new ToDo { Description = "Toplantıya katıl", Status = false, Priority = "Birincil" }
            };
            await _storeContext.ToDos.AddRangeAsync(todos);
            await _storeContext.SaveChangesAsync();
            return View();
        }
        public IActionResult ToDoAggreagatePriority()
        {
            var priorityFirstylyToDo = _storeContext.ToDos
                .Where(x => x.Priority == "Birincil").Select(y => y.Description).ToList();

            string result = priorityFirstylyToDo.Aggregate((acc, desc) => acc + " " + desc);
            ViewBag.results = result;
            return View();
        }
        public IActionResult IncompleteTask()
        {
            var values = _storeContext.ToDos
                .Where(x => !x.Status)
                .Select(y => y.Description)
                .ToList()
                .Prepend("Gün başında tüm görevleri kontrol etmeyi unutmayın!")
                .ToList();
            return View(values);
        }
        public IActionResult TodoChunk()
        {
            var values = _storeContext.ToDos
                .Where(x => !x.Status)
                .ToList()
                .Chunk(2)
                .ToList();
            return View(values);
        }
        public IActionResult TodoConcat()
        {
            var values = _storeContext.ToDos
                .Where(x => x.Priority == "Birincil")
                .ToList()
                .Concat(
                        _storeContext.ToDos.Where(y => y.Priority == "İkincil").ToList()
                )
                .ToList();
            return View(values);
        }
        public IActionResult TodoUnion()
        {
            var values = _storeContext.ToDos.Where(x => x.Priority == "Birincil").ToList();
            var values2 = _storeContext.ToDos.Where(x => x.Priority == "İkincil").ToList();
            var result = values.UnionBy(values2, x => x.Description).ToList();
            return View(result);
        }
    }
}
