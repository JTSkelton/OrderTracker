using Microsoft.AspNetCore.Mvc;

namespace OrderTracker.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
