namespace SpacePlace.Models
{
    public class Comment
    {
        public Guid ID { get; init; }
        public string Poster { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
    }
}
