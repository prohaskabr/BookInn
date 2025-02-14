using BookInn.Domain.Abstractions;
using MediatR;

namespace BookInn.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse>: IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
    
}