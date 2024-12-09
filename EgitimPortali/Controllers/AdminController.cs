using Microsoft.AspNetCore.Mvc;

namespace EgitimPortali.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
