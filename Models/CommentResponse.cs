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
        public bool IsDeleted { get; set; } = false;
        public List<Comment> Comments { get; set; }
        public ProfileRequest ProfileRequest { get; set; }
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
                    if (reply.IsDeleted)
                    {
                        html += "<p><i>" + reply.Content + "</i></p>";
                    }
                    else
                    {
                        html += "<p>" + reply.Content + "</p>";
                    }
                    html += "<button onclick=\"editComment('" + reply.ID + "')\" class=\"btn\">Edit</button>\r\n" +
                            "<form method=\"post\" action=\"/Comment/EditComment\" id=\"edit-" + reply.ID + "\" style=\"display:none\">\r\n" +
                                "<div class=\"form-group\">\r\n" +
                                    "<label for=\"Content\">Content:</label>\r\n" +
                                    "<input type=\"hidden\" name=\"id\" value=\"" + reply.ID + "\" />\r\n" +
                                    "<input type=\"text\" class=\"form-control\" id=\"Content\" name=\"Content\" asp-for=\"Content\" value=\"" + reply.Content + "\" required />\r\n" +
                                "</div>\r\n" +
                                "<button type=\"submit\" class=\"btn\">Submit</button>\r\n" +
                            "</form>" +
                            "<button onclick=\"cancelEdit('" + reply.ID + "')\" class=\"btn\" id=\"editbtn-" + reply.ID + "\" style=\"display:none\">Cancel</button>";
                    html += "<form method=\"post\" action=\"/Comment/DeleteComment\">\r\n" +
                                "<div class=\"form-group\">\r\n" +
                                    "<input type=\"hidden\" name=\"id\" value=\"" + reply.ID + "\" />\r\n" +
                                "</div>\r\n" +
                                "<button type=\"submit\" class=\"btn\">Delete</button>\r\n" +
                            "</form>";
                    html += "<p>Likes: " + reply.Likes + "</p>";
                    html += "<form method=\"post\" action=\"/Comment/LikeComment\">\r\n" +
                                "<div class=\"form-group\">\r\n" +
                                    "<input type=\"hidden\" name=\"id\" value=\"" + reply.ID + "\" />\r\n" +
                                "</div>\r\n" +
                                "<button type=\"submit\" class=\"btn\">Like</button>\r\n" +
                            "</form>";
                    html += "<p>Dislikes: " + reply.Dislikes + "</p>";
                    html += "<form method=\"post\" action=\"/Comment/DislikeComment\">\r\n" +
                                "<div class=\"form-group\">\r\n" +
                                    "<input type=\"hidden\" name=\"id\" value=\"" + reply.ID + "\" />\r\n" +
                                "</div>\r\n" +
                                "<button type=\"submit\" class=\"btn\">Dislike</button>\r\n" +
                            "</form>";
                    html += "<button onclick=\"replyComment('" + reply.ID +"')\" class=\"btn\">Reply</button><br/>" +
                            "<form method=\"post\" action=\"/Comment/PostComment\" id=\"reply-" + reply.ID + "\" style=\"display:none\">\r\n" +
                                "<div class=\"form-group\">\r\n" +
                                    "<label for=\"Content\">Content:</label>\r\n" +
                                    "<input type=\"hidden\" name=\"parentID\" value=\"" + reply.ID + "\" />\r\n" +
                                    "<input type=\"text\" class=\"form-control\" id=\"Content\" name=\"Content\" asp-for=\"Content\" required />\r\n" +
                                "</div>\r\n" +
                                "<button type=\"submit\" class=\"btn\">Submit</button>\r\n" +
                            "</form>" +
                            "<button onclick=\"cancelReply('" + reply.ID + "')\" class=\"btn\" id=\"replybtn-" + reply.ID + "\" style=\"display:none\">Cancel</button>";
                    html += DisplayReplies(reply);
                    html += "<br/>";
                }
            }
            return html;
        }
    }
}
