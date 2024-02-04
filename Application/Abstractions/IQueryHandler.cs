using MediatR;

namespace Application.Abstractions;

public interface IQueryHandler<in TQuery, TEntity> : IRequestHandler<TQuery, TEntity> where TQuery : IQuery<TEntity> { }