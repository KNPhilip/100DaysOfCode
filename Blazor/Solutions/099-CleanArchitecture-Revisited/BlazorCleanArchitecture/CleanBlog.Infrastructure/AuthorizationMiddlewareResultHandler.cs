using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace CleanBlog.Infrastructure;

public sealed class AuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
{
    public Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
    {
        return next(context);
    }
}
