using CleanBlog.Domain.Abstractions;
using MediatR;

namespace CleanBlog.Application.Abstractions.RequestHandling;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
