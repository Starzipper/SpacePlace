using Microsoft.AspNetCore.Mvc;
using SpacePlace.Models;
using SpacePlace.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SpacePlace.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _comRepository;
        private readonly IProfileRepository _profRepository;
        public CommentController(ICommentRepository comRepository, IProfileRepository profRepository)
        {
            _comRepository = comRepository;
            _profRepository = profRepository;
        }

        public IActionResult Index()
        {
            var request = new CommentRequest()
            {
                ID = Guid.Empty
            };
            var response = _comRepository.GetComments(request);

            if (!response.Success)
            {
                return RedirectToPage("Error");
            }
            return View(response);
        }

        public IActionResult ToLogin()
        {
            var request = new ProfileRequest();
            return View(request);
        }

        [HttpGet]
        public IActionResult ViewComment([FromRoute] Guid id)
        {
            var request = new CommentRequest()
            {
                ID = id
            };
            var response = _comRepository.GetComments(request);

            if (!response.Success)
            {
                return RedirectToPage("Error");
            }
            return View(response);
        }

        [HttpPost]
        public IActionResult PostComment(Guid parentID, Guid posterID, string poster, [FromForm] string content)
        {
            var request = new CommentRequest()
            {
                ParentID = parentID,
                PosterID = posterID,
                Poster = poster,
                Content = content
            };

            var response = _comRepository.PostComment(request);
            if (!response.Success)
            {
                return RedirectToPage("Error");
            }

            var profResponse = _profRepository.UpdateProfile(response.ProfileRequest);
            if (!profResponse.Success)
            {
                return RedirectToPage("Error");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditComment(Guid id, [FromForm] string content)
        {
            var request = new CommentRequest()
            {
                ID = id,
                Content = content
            };
            var response = _comRepository.EditComment(request);

            if (!response.Success)
            {
                return RedirectToPage("Error");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteComment(Guid id)
        {
            var request = new CommentRequest()
            {
                ID = id
            };
            var response = _comRepository.DeleteComment(request);

            if (!response.Success)
            {
                return Redirect("/Comment/Error");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult LikeComment(Guid id)
        {
            var request = new CommentRequest()
            {
                ID = id
            };
            var response = _comRepository.LikeComment(request);

            if (!response.Success)
            {
                return RedirectToPage("Error");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DislikeComment(Guid id)
        {
            var request = new CommentRequest()
            {
                ID = id
            };
            var response = _comRepository.DislikeComment(request);

            if (!response.Success)
            {
                return Redirect("/Comment/Error");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Login([FromForm]string username, [FromForm]string password)
        {
            var request = new ProfileRequest()
            {
                UserName = username,
                PasswordAttempt = password
            };
            var response = _profRepository.Login(request);

            if (!response.Success)
            {
                return RedirectToAction("Error");
            }
            Models.User.LoggedIn = true;
            Models.User.UserID = response.ID;

            return RedirectToAction("Index");
        }
    }
}
