using EVOffice_BE.Common;

namespace EVOffice_BE.Modules.User.Models;

public class CreateUserModel
{
    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}

public class CreateUserResponseModel : BaseResponseModel { }
