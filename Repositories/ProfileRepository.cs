using SpacePlace.Models;

namespace SpacePlace.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        public List<Profile> Profiles { get; set; } = new List<Profile>()
        {
            new Profile()
            {
                UserName = "supermastergameplayer23"
            },
            new Profile()
            {
                UserName = "imAgoofyGooberYEAH"
            },
            new Profile()
            {
                UserName = "Sleve McDichael"
            },
            new Profile()
            {
                UserName = "Beffica Winklesnoot"
            },
            new Profile()
            {
                UserName = "needsspeed"
            }
        };
        public ProfileResponse CreateProfile(ProfileRequest request)
        {
            try
            {
                var profile = new Profile()
                {
                    UserName = request.UserName,
                };
                profile.SetPassword(request.GetPassword());
                Profiles.Add(profile);

                return new ProfileResponse()
                {
                    ID = profile.ID,
                    UserName = request.UserName,
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new ProfileResponse()
                {
                    UserName = request.UserName,
                    Success = false,
                    ErrorMessage = exception.Message
                };
            }
        }
        public ProfileResponse ViewProfile(ProfileRequest request)
        {
            try
            {
                var profile = Profiles.Where(prof => prof.ID == request.ID).FirstOrDefault();
                if (profile == null)
                {
                    return new ProfileResponse()
                    {
                        ID = request.ID,
                        Success = false,
                        ErrorMessage = "Profile not found."
                    };
                }

                return new ProfileResponse()
                {
                    ID = request.ID,
                    UserName = profile.UserName,
                    CommentHistory = profile.CommentHistory,
                    Friends = profile.Friends,
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new ProfileResponse()
                {
                    ID = request.ID,
                    Success = false,
                    ErrorMessage = exception.Message
                };
            }
        }
        public ProfileResponse UpdateProfile(ProfileRequest request)
        {
            try
            {
                var profile = Profiles.Where(prof => prof.ID == request.ID).FirstOrDefault();
                if (profile == null)
                {
                    return new ProfileResponse()
                    {
                        ID = request.ID,
                        Success = false,
                        ErrorMessage = "Profile not found."
                    };
                }
                if (request.UserName != String.Empty)
                {
                    profile.UserName = request.UserName;
                }
                if (request.Comment != null)
                {
                    profile.CommentHistory.Add(request.Comment);
                }

                return new ProfileResponse()
                {
                    ID = request.ID,
                    UserName = profile.UserName,
                    CommentHistory = profile.CommentHistory,
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new ProfileResponse()
                {
                    ID = request.ID,
                    Success = false,
                    ErrorMessage = exception.Message
                };
            }
        }
        public ProfileResponse DeleteProfile(ProfileRequest request)
        {
            try
            {
                var profile = Profiles.Where(prof => prof.ID == request.ID).FirstOrDefault();
                if (profile == null)
                {
                    return new ProfileResponse()
                    {
                        ID = request.ID,
                        Success = false,
                        ErrorMessage = "Profile not found."
                    };
                }
                Profiles.Remove(profile);

                return new ProfileResponse()
                {
                    ID = request.ID,
                    Success = true
                };
            }
            catch (Exception exception)
            {
                return new ProfileResponse()
                {
                    ID = request.ID,
                    Success = false,
                    ErrorMessage = exception.Message
                };
            }
        }
        public ProfileResponse Login(ProfileRequest request)
        {
            try
            {
                var profiles = Profiles.Where(prof => prof.UserName == request.UserName).ToList();
                if (profiles.Count == 0)
                {
                    return new ProfileResponse()
                    {
                        ErrorMessage = "Incorrect username or password.",
                        Success = false
                    };
                }
                foreach (Profile profile in profiles)
                {
                    var password = profile.GetPassword();
                    if (password == request.PasswordAttempt)
                    {
                        return new ProfileResponse()
                        {
                            ID = profile.ID,
                            UserName = profile.UserName,
                            Success = true
                        };
                    }
                }
                return new ProfileResponse()
                {
                    ErrorMessage = "Incorrect username or password.",
                    Success = false
                };
            }
            catch (Exception exception)
            {
                return new ProfileResponse()
                {
                    ErrorMessage = exception.Message,
                    Success = false
                };
            }
        }
    }
}
