using EVOffice_BE.Common;
using EVOffice_BE.Modules.User.Models;

namespace EVOffice_BE.Modules.User.Services;

public interface IUserService
{
    Task<BaseResponseModel> ChangePasswordAsync(Guid userId, ChangePasswordModel changePasswordModel);

    Task<CreateUserResponseModel> CreateAsync(CreateUserModel createUserModel);

    Task<LoginResponseModel> LoginAsync(LoginUserModel loginUserModel);
}
