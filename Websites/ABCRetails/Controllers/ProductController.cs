using Microsoft.AspNetCore.Mvc;

namespace ABCRetails.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
