using Microsoft.AspNetCore.Mvc;
using OrderTracker.Data;
using OrderTracker.Models;

namespace OrderTracker.Controllers
{
    public class VendorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VendorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Vendor> objectCatagoryList = _db.Vendors;
            return View(objectCatagoryList);
        }

        //GET
        public IActionResult CreateVendor()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateVendor(Vendor obj)
        {
            if (ModelState.IsValid)
            {
                _db.Vendors.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Vendor Successfully Added!";
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
            var vendorFromDb = _db.Vendors.Find(id);
            if (vendorFromDb == null)
            {
                return NotFound();
            }
            return View(vendorFromDb);
        }

        //EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Vendor obj)
        {
            if (ModelState.IsValid)
            {
                _db.Vendors.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Vendor Updated Successfully!";
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
            var vendorFromDb = _db.Vendors.Find(id);
            if (vendorFromDb == null)
            {
                return NotFound();
            }
            return View(vendorFromDb);
        }

        //DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Vendors.Find(id);
            if (obj == null)
            { return NotFound();}

            _db.Vendors.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Vendor Deleted Successfully!";
            return RedirectToAction("Index");

        }
    }
}
