using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using NTierArchitecture.Common;
using NTierArchitecture.Modules.User.Models;
using NTierArchitecture.Modules.User.Services;

namespace NTierArchitecture.Modules.User;

public class UsersController : ApiController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("authenticate")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync(LoginUserModel loginUserModel)
    {
        return Ok(ApiResult<LoginResponseModel>.Success(StatusCodes.Status200OK, await _userService.LoginAsync(loginUserModel)));
    }

    [HttpPut("{id:guid}/changePassword")]
    public async Task<IActionResult> ChangePassword(Guid id, ChangePasswordModel changePasswordModel)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(StatusCodes.Status200OK,
            await _userService.ChangePasswordAsync(id, changePasswordModel)));
    }
}
