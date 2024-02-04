using MediatR;

namespace Application.Abstractions;

public interface IQuery<out TEntity> : IRequest<TEntity> { }