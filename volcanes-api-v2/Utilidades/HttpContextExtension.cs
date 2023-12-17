using Microsoft.EntityFrameworkCore;

namespace volcanes_api_v2.Utilidades;

public static class HttpContextExtension
{
    public async static Task InsertarParametros<T>(this HttpContext httpContext,IQueryable<T> queryable)
    {
        if (httpContext == null)
            throw new ArgumentNullException(nameof(httpContext));
        var cantidad = await queryable.CountAsync();
        httpContext.Response.Headers.Add("cantidadTotalRegistros",cantidad.ToString());
    }
}