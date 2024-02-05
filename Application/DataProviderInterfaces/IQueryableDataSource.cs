namespace Application.DataProviderInterfaces;

public interface IQueryableDataSource
{
    Task<List<T>> Query<T>(FormattableString sql);

    Task<T?> QuerySingle<T>(FormattableString sql);
}