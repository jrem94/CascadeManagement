using Application.DataProviderInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataProviders;

public class QueryableDataSource : IQueryableDataSource
{
    private readonly CascadeManagementDbContext _dbContext;
    
    public QueryableDataSource(CascadeManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<T>> Query<T>(FormattableString sql)
    {
        return await _dbContext.Database.SqlQuery<T>(sql).ToListAsync();
    }

    public async Task<T?> QuerySingle<T>(FormattableString sql)
    {
        return await _dbContext.Database.SqlQuery<T>(sql).SingleOrDefaultAsync();
    }
}