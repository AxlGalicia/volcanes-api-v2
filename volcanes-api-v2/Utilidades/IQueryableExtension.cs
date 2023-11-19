using volcanes_api_v2.Models.DTOs;

namespace volcanes_api_v2.Utilidades;

public static class IQueryableExtension
{
    public static IQueryable<T> paginar<T>(this IQueryable<T> queryable, PaginacionDTO paginacionDto)
    {
        return queryable.Skip((paginacionDto.Pagina - 1) * paginacionDto.RegistrosPorPagina)
            .Take(paginacionDto.RegistrosPorPagina);

    }
}