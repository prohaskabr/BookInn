using BookInn.Domain.Abstractions;
using MediatR;

namespace BookInn.Application.Abstractions.Messaging;

public interface ICommand: IRequest<Result>,IBaseCommand
{
}

public interface ICommand<TResponse>: IRequest<Result<TResponse>>,IBaseCommand
{
}
