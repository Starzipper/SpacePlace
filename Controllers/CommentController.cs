using Microsoft.AspNetCore.Mvc;
using SpacePlace.Models;
using SpacePlace.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SpacePlace.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _repository;
        public CommentController(ICommentRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var request = new CommentRequest()
            {
                ID = Guid.Empty
            };
            var response = _repository.GetComments(request);

            if (!response.Success)
            {
                return RedirectToPage("Error");
            }
            return View(response);
        }

        [HttpGet]
        public IActionResult ViewComment([FromRoute] Guid id)
        {
            var request = new CommentRequest()
            {
                ID = id
            };
            var response = _repository.GetComments(request);

            if (!response.Success)
            {
                return RedirectToPage("Error");
            }
            return View(response);
        }

        [HttpPost]
        public IActionResult PostComment([FromForm] string poster, [FromForm] string content)
        {
            var request = new CommentRequest()
            {
                Poster = poster,
                Content = content
            };
            var response = _repository.PostComment(request);

            if (!response.Success)
            {
                return RedirectToPage("Error");
            }
            return View(response);
        }

        [HttpPut]
        public IActionResult EditComment(Guid id, [FromForm] string content)
        {
            var request = new CommentRequest()
            {
                ID = id,
                Content = content
            };
            var response = _repository.EditComment(request);

            if (!response.Success)
            {
                return RedirectToPage("Error");
            }
            return View(response);
        }

        [HttpDelete]
        public IActionResult DeleteComment(Guid id)
        {
            var request = new CommentRequest()
            {
                ID = id
            };
            var response = _repository.DeleteComment(request);

            if (!response.Success)
            {
                return RedirectToPage("Error");
            }
            return View(response);
        }
    }
}
