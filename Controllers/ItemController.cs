using Microsoft.AspNetCore.Mvc;

namespace CoreEComMVC.Controllers
{
    public class ItemController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
