using Microsoft.AspNetCore.Mvc;

namespace SpacePlace.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
