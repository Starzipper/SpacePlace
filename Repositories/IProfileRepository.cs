using SpacePlace.Models;

namespace SpacePlace.Repositories
{
    public interface IProfileRepository
    {
        public List<Profile> Profiles { get; }
        public ProfileResponse CreateProfile(ProfileRequest request);
        public ProfileResponse ViewProfile(ProfileRequest request);
        public ProfileResponse UpdateProfile(ProfileRequest request);
        public ProfileResponse DeleteProfile(ProfileRequest request);
    }
}
