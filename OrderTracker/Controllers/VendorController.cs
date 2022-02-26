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
    }
}
