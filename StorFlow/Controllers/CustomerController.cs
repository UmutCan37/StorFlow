using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorFlow.Context;
using StorFlow.Entities;
using StorFlow.Models;

namespace StorFlow.Controllers
{
    public class CustomerController : Controller
    {
        private readonly StoreContext _storeContext;

        public CustomerController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IActionResult Index()
        {
            var values = _storeContext.Customers.OrderBy(x=>x.CustomerName).ToList();
            return View(values);
        }
        public IActionResult CustomerListOrderByDescBalance()
        {
            var values = _storeContext.Customers.OrderByDescending(x => x.CustomerBalance).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer Customer)
        {
            
            _storeContext.Customers.Add(Customer);
            _storeContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCustomer(int id)
        {
            var values = _storeContext.Customers.Find(id);
            _storeContext.Customers.Remove(values);
            _storeContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var values = _storeContext.Customers.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer Customer)
        {
            _storeContext.Customers.Update(Customer);
            _storeContext.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult CustomerGetByCity(string city)
        {
            var exist = _storeContext.Customers.Any(x => x.CustomerCity == city);
            if (exist)
            {
                ViewBag.message = $"{city} şehrinde en az 1 tane müşteri var"; 
            }
            else
            {
                ViewBag.message = $"{city} şehrinde hiç müşteri yok";
            }
            return View();
        }
        public IActionResult CustomerListByCity()
        {
            var groupedCustomers = _storeContext.Customers
                .ToList()
                .GroupBy(c => c.CustomerCity)
                .ToList();
            return View(groupedCustomers);
        }
        public IActionResult CustomersByCityCount()
        {
            var query =
                from c in _storeContext.Customers
                group c by c.CustomerCity into cityGroup
                select new CustomerCityGroup
                {
                    City = cityGroup.Key,
                    CustomerCount = cityGroup.Count()
                };
            var model = query.ToList();
            return View(model);
        }
        public IActionResult CustomerCityList()
        {
            var values = _storeContext.Customers.Select(x => x.CustomerCity).Distinct().ToList();
            return View(values);
        }
        public IActionResult ParallelCustomers()
        {
            var customers = _storeContext.Customers.ToList();
            var result = customers.AsParallel().Where(c => c.CustomerCity.StartsWith("A", StringComparison.OrdinalIgnoreCase)).ToList();
            return View(result);
        }
        public IActionResult CustomerCityExceptCityİstanbul()
        {
            var allCustomers = _storeContext.Customers.ToList();
            var customersListInIstanbul = _storeContext.Customers
                .Where(x => x.CustomerCity == "İstanbul")
                .Select(c => c.CustomerCity)
                .ToList();
            var result = allCustomers.ExceptBy(customersListInIstanbul, c => c.CustomerCity).ToList();

            return View(result);
        }
        public IActionResult CustomerListWithDefaultIfEmpty()
        {
            var customers = _storeContext.Customers.Where(x => x.CustomerCity == "Ankara").ToList().DefaultIfEmpty(new Customer
            {
                CustomerId = 0,
                CustomerName = "Kayıt Yok",
                CustomerSurname = "---",
                CustomerCity = "Ankara"
            }).ToList();
            return View(customers);
        }
        public IActionResult CustomerListWithIndex()
        {
            var customers = _storeContext.Customers
                .ToList()
                .Select((c, index) => new
                {
                    SiraNo = index + 1,
                    c.CustomerName,
                    c.CustomerSurname,
                    c.CustomerCity
                })
                .ToList();
            return View(customers);
        }

    }
}
