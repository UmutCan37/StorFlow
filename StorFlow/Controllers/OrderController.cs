using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StorFlow.Context;
using StorFlow.Entities;
using StorFlow.Models;

namespace StorFlow.Controllers
{
    public class OrderController : Controller
    {
        private readonly StoreContext _context;

        public OrderController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult AllStockSmallerThen5()
        {
            bool orderStockCount = _context.Orders.All(x => x.OrderCount <= 5);
            if (orderStockCount)
            {
                ViewBag.v = "Tüm siparişler 5den küçüktür";
            }
            else
            {
                ViewBag.v = "Tüm siparişler 5den küçük değildir.";
            }
            return View();
        }
        public IActionResult OrderListByStatus(string status)
        {
            var values = _context.Orders.Where(x => x.Status.Contains(status)).ToList();
            if (!values.Any())
            {
                ViewBag.v = "bu status ile ilgili veri bulunamadı";
            }
            return View(values);
        }
        public IActionResult OrderListSearch(string name,string filtertype)
        {
            var value = _context.Orders.ToList();
            if (filtertype == "start")
            {
                var values = _context.Orders.Where(x => x.Status.StartsWith(name)).ToList();
                return View(values);
            }
            else if(filtertype=="end")
            {
                var values = _context.Orders.Where(x => x.Status.EndsWith(name)).ToList();
                return View(values);
            }
            return View(value);
        }
        public async Task<IActionResult> OrderList()
        {
            var values =await _context.Orders.Include(x => x.Product).Include(y => y.Customer).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            var customers = _context.Customers
                            .Select(c => new SelectListItem
                            {
                                Value=c.CustomerId.ToString(),
                                Text=c.CustomerName +" "+ c.CustomerSurname
                            }).ToList();
            ViewBag.customers = customers;
            var products = _context.Products
                            .Select(c => new SelectListItem
                            {
                                Value = c.ProductId.ToString(),
                                Text = c.ProductName
                            }).ToList();
            ViewBag.products = products;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            order.Status = "Sipariş Alındı";
            order.OrderDate = DateTime.Now;
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderList");
        }
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var values = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(values);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            var customers = _context.Customers
                            .Select(c => new SelectListItem
                            {
                                Value = c.CustomerId.ToString(),
                                Text = c.CustomerName + " " + c.CustomerSurname
                            }).ToList();
            ViewBag.customers = customers;
            var products = _context.Products
                            .Select(c => new SelectListItem
                            {
                                Value = c.ProductId.ToString(),
                                Text = c.ProductName
                            }).ToList();
            ViewBag.products = products;
            var values = await _context.Orders.FindAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderList");
        }
        public IActionResult OrderListWithCustomerGroup()
        {
            var result = from customer in _context.Customers
                         join order in _context.Orders
                         on customer.CustomerId equals order.CustomerId
                         into orderGroup
                         select new CustomerOrderViewModel
                         {
                             CustomerName = customer.CustomerName + " " + customer.CustomerSurname,
                             Orders = orderGroup.ToList()
                         };
            return View(result.ToList());
        }
    }
}
