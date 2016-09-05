using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavRocks.Site.Controllers
{
    public class ResetController : Controller
    {
        public ResetController(ISession session)
        {
            this.session = session;
        }

        private readonly ISession session;

        [HttpGet]
        [Route("reset")]
        public IActionResult Index()
        {
            session.Remove("pixelBoard");

            return RedirectToAction("Index", "Home");
        }
    }
}
