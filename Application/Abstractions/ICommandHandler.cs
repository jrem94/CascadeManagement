using MediatR;

namespace Application.Abstractions;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand { }