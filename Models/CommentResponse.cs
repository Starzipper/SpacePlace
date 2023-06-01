namespace SpacePlace.Models
{
    public class CommentResponse
    {
        public Guid ID { get; set; }
        public Guid ParentID { get; set; }
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
                    html += "<button onclick=\"replyComment('" + reply.ID +"')\" class=\"btn\">Reply</button><br/>" +
                            "<form method=\"post\" asp-action=\"PostComment\" id=\"reply-"+ reply.ID +"\" style=\"display:none\">\r\n" +
                                "<div class=\"form-group\">\r\n" +
                                    "<label for=\"Content\">Content:</label>\r\n" +
                                    "<input type=\"hidden\" name=\"id\" value=\""+ reply.ID +"\" />\r\n" +
                                    "<input type=\"text\" class=\"form-control\" id=\"Content\" name=\"Content\" asp-for=\"Content\" required />\r\n" +
                                "</div>\r\n" +
                                "<button type=\"submit\" class=\"btn\">Submit</button>\r\n" +
                                "<button onclick=\"cancelReply('" + reply.ID +"')\" class=\"btn\">Cancel</button>\r\n" +
                            "</form>";
                    html += DisplayReplies(reply);
                    html += "<br/>";
                }
            }
            return html;
        }
    }
}
