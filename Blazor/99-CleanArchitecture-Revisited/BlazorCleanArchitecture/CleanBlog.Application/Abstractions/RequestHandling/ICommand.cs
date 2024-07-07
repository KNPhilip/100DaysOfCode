using CleanBlog.Domain.Abstractions;
using MediatR;

namespace CleanBlog.Application.Abstractions.RequestHandling;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
