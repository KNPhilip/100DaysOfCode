namespace CleanBlog.Application.Users.RegisterUser;

public sealed class RegisterUserCommand : ICommand
{
    public required string UserName { get; set; }
    public required string UserEmail { get; set; }
    public required string Password { get; set; }
}
