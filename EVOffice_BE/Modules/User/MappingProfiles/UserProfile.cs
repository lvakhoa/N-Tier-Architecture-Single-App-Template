using AutoMapper;

using EVOffice_BE.Modules.User.Config;
using EVOffice_BE.Modules.User.Models;

namespace EVOffice_BE.Modules.User.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserModel, ApplicationUser>();
    }
}
