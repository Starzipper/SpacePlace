using SpacePlace.Models;

namespace SpacePlace.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public List<Comment> Comments { get; set; }
        public CommentResponse GetComments(CommentRequest request)
        {
            try
            {
                if (request.ID == Guid.Empty)
                {
                    return new CommentResponse()
                    {
                        Comments = Comments,
                        Success = true
                    };
                }

                var comment = Comments.Where(com => com.ID == request.ID).FirstOrDefault();
                if (comment == null)
                {
                    return new CommentResponse()
                    {
                        ID = request.ID,
                        ErrorMessage = "Comment not found.",
                        Success = false
                    };
                }

                return new CommentResponse()
                {
                    ID = comment.ID,
                    Poster = comment.Poster,
                    Content = comment.Content,
                    Likes = comment.Likes,
                    Dislikes = comment.Dislikes,
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new CommentResponse()
                {
                    ID = request.ID,
                    ErrorMessage = exception.Message,
                    Success = false
                };
            }
        }
        public CommentResponse PostComment(CommentRequest request)
        {
            try
            {
                var comment = new Comment()
                {
                    Poster = request.Poster,
                    Content = request.Content
                };
                Comments.Add(comment);

                return new CommentResponse()
                {
                    ID = comment.ID,
                    Poster = request.Poster,
                    Content = request.Content,
                    Likes = comment.Likes,
                    Dislikes = comment.Dislikes,
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new CommentResponse()
                {
                    ErrorMessage = exception.Message,
                    Success = false
                };
            }
        }
        public CommentResponse EditComment(CommentRequest request)
        {
            try
            {
                var index = Comments.FindIndex(com => com.ID == request.ID);
                if (index == -1)
                {
                    return new CommentResponse()
                    {
                        ID = request.ID,
                        ErrorMessage = "Comment not found.",
                        Success = false
                    };
                }
                Comments[index].Content = request.Content;

                return new CommentResponse()
                {
                    ID = request.ID,
                    Poster = request.Poster,
                    Content = request.Content,
                    Likes = request.Likes,
                    Dislikes = request.Dislikes,
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new CommentResponse()
                {
                    ID = request.ID,
                    ErrorMessage = exception.Message,
                    Success = false
                };
            }
        }
        public CommentResponse DeleteComment(CommentRequest request)
        {
            try
            {
                var comment = Comments.Where(com => com.ID == request.ID).FirstOrDefault();
                if (comment == null)
                {
                    return new CommentResponse()
                    {
                        ID = request.ID,
                        ErrorMessage = "Comment not found.",
                        Success = false
                    };
                }
                Comments.Remove(comment);

                return new CommentResponse()
                {
                    ID = request.ID,
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new CommentResponse()
                {
                    ID = request.ID,
                    ErrorMessage = exception.Message,
                    Success = false
                };
            }
        }
    }
}
