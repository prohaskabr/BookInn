using BookInn.Domain.Abstractions;
using MediatR;

namespace BookInn.Application.Abstractions.Messaging;

public interface IQuery<TResponse>: IRequest<Result<TResponse>>
{
    
}