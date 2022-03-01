using Microsoft.AspNetCore.Mvc;
using OrderTracker.Data;
using OrderTracker.Models;

namespace OrderTracker.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Order> orderCatagoryList = _db.Orders;
            return View(orderCatagoryList);
        }

        //GET
        public IActionResult CreateOrder()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrder(Order obj)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Order Successfully Added!";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var orderFromDb = _db.Orders.Find(id);
            if (orderFromDb == null)
            {
                return NotFound();
            }
            return View(orderFromDb);
        }

        //GET
        public IActionResult ViewVendorOrders(string? name)
        {
            if (name == null)
            {
                return NotFound();
            }
            var orderFromDb = _db.Orders.Find(name);
            if (orderFromDb == null)
            {
                return NotFound();
            }
            return View(orderFromDb);
        }


        //EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order obj)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Order Updated Successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var orderFromDb = _db.Orders.Find(id);
            if (orderFromDb == null)
            {
                return NotFound();
            }
            return View(orderFromDb);
        }

        //DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Orders.Find(id);
            if (obj == null)
            { return NotFound(); }

            _db.Orders.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Order Deleted Successfully!";
            return RedirectToAction("Index");

        }
    }
}
