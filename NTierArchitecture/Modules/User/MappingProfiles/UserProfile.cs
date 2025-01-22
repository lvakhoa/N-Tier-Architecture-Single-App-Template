using AutoMapper;

using NTierArchitecture.Modules.User.Config;
using NTierArchitecture.Modules.User.Models;

namespace NTierArchitecture.Modules.User.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserModel, ApplicationUser>();
    }
}
