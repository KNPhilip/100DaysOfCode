using CleanBlog.Domain.Abstractions;
using MediatR;

namespace CleanBlog.Application.Abstractions.RequestHandling;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
{
}
