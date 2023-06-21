namespace SpacePlace.Models
{
    public class ProfileResponse
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        private string Password { get; set; }
        public string PasswordAttempt { get; set; }
        public List<Comment> CommentHistory { get; set; }
        public List<Profile> Friends { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
    }
}
