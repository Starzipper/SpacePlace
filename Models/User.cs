namespace SpacePlace.Models
{
    public static class User
    {
        public static bool LoggedIn { get; set; } = false;
        public static Guid UserID { get; set; }
    }
}
