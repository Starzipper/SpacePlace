namespace SpacePlace.Models
{
    public class CommentRequest
    {
        public Guid ID { get; set; }
        public Guid ParentID { get; set; }
        public string Poster { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public List<Comment> Replies { get; set; }
    }
}
