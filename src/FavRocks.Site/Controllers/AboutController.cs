using Microsoft.AspNetCore.Mvc;

namespace FavRocks.Site.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet]
        [Route("about")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
