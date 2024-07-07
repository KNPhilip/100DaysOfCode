namespace CleanBlog.Application.Users.LoginUser;

public sealed class LoginUserCommand : ICommand
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}
