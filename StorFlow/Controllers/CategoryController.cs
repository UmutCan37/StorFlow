using Microsoft.AspNetCore.Mvc;
using StorFlow.Context;
using StorFlow.Entities;

namespace StorFlow.Controllers
{
    public class CategoryController : Controller
    {
        private readonly StoreContext _storeContext;

        public CategoryController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IActionResult Index()
        {
            var values = _storeContext.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            category.CategoryStatus = false;
            _storeContext.Categories.Add(category);
            _storeContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id)
        {
            var values = _storeContext.Categories.Find(id);
            _storeContext.Categories.Remove(values);
            _storeContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var values = _storeContext.Categories.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _storeContext.Categories.Update(category);
            _storeContext.SaveChanges();
            return RedirectToAction("Index");
        
        }
        public IActionResult ReverseCategory()
        {
            var categoryvalue = _storeContext.Categories.First();
            ViewBag.v = categoryvalue.CategoryName;

            var categoryvalue2 = _storeContext.Categories.SingleOrDefault(x => x.CategoryName == "Anne ve Bebek Ürünleri");
            ViewBag.v2 = categoryvalue2.CategoryStatus + "-" +categoryvalue2.CategoryId.ToString();

            var values = _storeContext.Categories.OrderBy(x=>x.CategoryId).ToList();
            values.Reverse();

            return View(values);
        }

            
    }
}
