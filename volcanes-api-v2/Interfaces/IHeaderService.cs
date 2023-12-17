namespace volcanes_api_v2.Interfaces;

public interface IHeaderService
{
    Task InsertarParametros<T>(HttpContext httpContext, IQueryable<T> queryable);
}