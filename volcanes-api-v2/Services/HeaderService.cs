using Microsoft.EntityFrameworkCore;
using volcanes_api_v2.Interfaces;

namespace volcanes_api_v2.Services;

public class HeaderService : IHeaderService
{
    public async Task InsertarParametros<T>(HttpContext httpContext, IQueryable<T> queryable)
    {
        var cantidad = await queryable.CountAsync();
        httpContext.Response.Headers.Add("cantidadTotalRegistros",cantidad.ToString());
    }
}