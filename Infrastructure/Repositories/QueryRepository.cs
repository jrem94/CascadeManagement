using Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : class
{
    private readonly CascadeManagementDbContext _dbContext;
    
    public QueryRepository(CascadeManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public IQueryable<TEntity> GetQueryable()
    {
        return _dbContext.Set<TEntity>();
    }
}