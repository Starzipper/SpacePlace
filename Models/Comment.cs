namespace SpacePlace.Models
{
    public class Comment
    {
        public Guid ID { get; init; }
        public string Poster { get; set; } // TODO: Add a dedicated Profile class
        public string Content { get; set; }
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
        public List<Comment> Replies { get; set; } = new List<Comment>();
    }
}
