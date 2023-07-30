using Microsoft.AspNetCore.Mvc;

namespace WebCoreAPI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
