using EVOffice_BE.Common;
using EVOffice_BE.Modules.User.Models;
using EVOffice_BE.Modules.User.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EVOffice_BE.Modules.User;

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
        return Ok(ApiResult<LoginResponseModel>.Success(await _userService.LoginAsync(loginUserModel)));
    }

    [HttpPut("{id:guid}/changePassword")]
    public async Task<IActionResult> ChangePassword(Guid id, ChangePasswordModel changePasswordModel)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(
            await _userService.ChangePasswordAsync(id, changePasswordModel)));
    }
}
