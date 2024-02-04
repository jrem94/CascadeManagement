namespace Application.Repositories;

public interface IQueryRepository<TEntity>
{
    Task<List<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(Guid id);

    IQueryable<TEntity> GetQueryable();
}