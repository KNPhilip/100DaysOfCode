using CleanBlog.Application.Authentication;

namespace CleanBlog.Application.Users.LoginUser;

public sealed class LoginUserCommandHandler(IAuthenticationService authenticationService) 
    : ICommandHandler<LoginUserCommand>
{
    private readonly IAuthenticationService _authenticationService = authenticationService;

    public async Task<Result> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        bool success = await _authenticationService.LoginUserAsync(
            request.UserName,
            request.Password
        );

        if (success)
        {
            return Result.Ok();
        }

        return Result.Fail("Username or password is wrong.");
    }
}
