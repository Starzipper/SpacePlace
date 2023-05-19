namespace SpacePlace.Models
{
    public class CommentResponse
    {
        public Guid ID { get; set; }
        public string Poster { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
    }
}
