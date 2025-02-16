namespace NTierArchitecture.Modules.User.Models;

public class LoginUserModel
{
    public string Username { get; set; }

    public string Password { get; set; }
}

public class LoginResponseModel
{
    public string Username { get; set; }

    public string Email { get; set; }

    public string Token { get; set; }
}
