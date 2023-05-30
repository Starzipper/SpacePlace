namespace SpacePlace.Models
{
    public class CommentResponse
    {
        public Guid ID { get; set; }
        public string Poster { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public List<Comment> Replies { get; set; }
        public List<Comment> Comments { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
        public string DisplayReplies(Comment comment)
        {
            var html = "";
            if (comment.Replies.Count != 0)
            {
                html += "<p>Replies: </p>";
                foreach (var reply in comment.Replies)
                {
                    html += "<p>Poster: " + reply.Poster + "</p>";
                    html += "<p>" + reply.Content + "</p>";
                    html += "<p>Likes: " + reply.Likes + "</p>";
                    html += "<p>Dislikes: " + reply.Dislikes + "</p>";
                    html += DisplayReplies(reply);
                    html += "<br/>";
                }
            }
            return html;
        }
    }
}
