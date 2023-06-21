namespace SpacePlace.Models
{
    public class Profile
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        private string Password { get; set; } = "testing";
        public List<Comment> CommentHistory { get; set; } = new List<Comment>();
        public List<Profile> Friends { get; set; }
        public string GetPassword()
        {
            return Password;
        }
        public void SetPassword(string password)
        {
            Password = password;
        }
    }
}
