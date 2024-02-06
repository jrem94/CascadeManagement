namespace Application.InfrastructurePorts;

public interface IQueryableDataSource
{
    Task<List<T>> QueryList<T>(FormattableString sql);

    Task<T?> QuerySingle<T>(FormattableString sql);

    Task<T?> QueryFirst<T>(FormattableString sql);
}