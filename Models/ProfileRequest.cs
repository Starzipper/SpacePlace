namespace SpacePlace.Models
{
    public class ProfileRequest
    {
        public Guid ID { get; set; }
        public Comment Comment { get; set; }
        public string UserName { get; set; }
        public string PasswordAttempt { get; set; }
        private string Password { get; set; }
        public List<Comment> CommentHistory { get; set; }
        public List<Profile> Friends { get; set; }
        public string GetPassword()
        {
            return Password;
        }
    }
}
