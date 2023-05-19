using SpacePlace.Models;

namespace SpacePlace.Repositories
{
    public interface ICommentRepository
    {
        public List<Comment> Comments { get; set; }
        public CommentResponse GetComments(CommentRequest request);
        public CommentResponse PostComment(CommentRequest request);
        public CommentResponse EditComment(CommentRequest request);
        public CommentResponse DeleteComment(CommentRequest request);
    }
}
