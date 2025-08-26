using Microsoft.AspNetCore.Mvc;

namespace ABCRetails.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
