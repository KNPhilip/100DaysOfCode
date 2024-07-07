using CleanBlog.Application.Authentication;

namespace CleanBlog.Application.Users.RegisterUser;

public sealed class RegisterUserCommandHandler(IAuthenticationService authenticationService) 
    : ICommandHandler<RegisterUserCommand>
{
    private readonly IAuthenticationService _authenticationService = authenticationService;

    public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        RegisterUserResponse result = await _authenticationService.RegisterUserAsync(
            request.UserName,
            request.UserEmail,
            request.Password
        );

        if (result.Succeeded)
        {
            return Result.Ok();
        }

        return Result.Fail($"{string.Join(", ", result.Errors)}");
    }
}
