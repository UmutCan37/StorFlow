using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StorFlow.Context;
using StorFlow.Entities;
using StorFlow.Models;

namespace StorFlow.Controllers
{
    public class ProductController : Controller
    {
        private readonly StoreContext _storeContext;

        public ProductController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IActionResult Index()
        {
            var values = _storeContext.Products.Include(x => x.Category).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            var categories = _storeContext.Categories
                                            .Select(c => new SelectListItem
                                            {
                                                Value=c.CategoryId.ToString(),
                                                Text=c.CategoryName
                                            });
            ViewBag.categories = categories;
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product Product)
        {
            
            _storeContext.Products.Add(Product);
            _storeContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            var values = _storeContext.Products.Find(id);
            _storeContext.Products.Remove(values);
            _storeContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var categories = _storeContext.Categories
                                            .Select(c => new SelectListItem
                                            {
                                                Value = c.CategoryId.ToString(),
                                                Text = c.CategoryName
                                            });
            ViewBag.Categories = categories;
            var values = _storeContext.Products.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product Product)
        {
            _storeContext.Products.Update(Product);
            _storeContext.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult First5ProductLİst()
        {
            var values = _storeContext.Products.Include(x=>x.Category).Take(5).ToList();
            return View(values);
        }
        public IActionResult Skip4ProductList()
        {
            var values = _storeContext.Products.Include(x => x.Category).Skip(4).Take(10).ToList();
            return View(values);
        }
        public IActionResult CreateProductWithAttach()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateProductWithAttach(Product product)
        {
            var category = new Category { CategoryId = 1 };
            _storeContext.Categories.Attach(category);

            var productValue = new Product
            {
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductStock = product.ProductStock,
                Category = category
            };

            _storeContext.Products.Add(productValue);
            _storeContext.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public IActionResult ProductCount()
        {
            var value = _storeContext.Products.LongCount();
            var lastProduct = _storeContext.Products.OrderBy(x => x.ProductId).Last();
            ViewBag.v2 = lastProduct.ProductName;
            ViewBag.v = value;
            return View();
        }
        public IActionResult ProductListWithCategory()
        {
            var result = from c in _storeContext.Categories
                         join p in _storeContext.Products
                         on
                         c.CategoryId equals p.CategoryId
                         select new ProductWithCategoryViewModel
                         {
                             ProductName=p.ProductName,
                             ProductStock=p.ProductStock,
                             CategoryName=c.CategoryName
                         };
            
            return View(result.ToList());
        }

    }
}
