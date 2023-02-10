using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using DigitalPark.Application.Common.Models;

namespace DigitalPark.Application.Common.Extensions;

internal static class QueryExtensions
{
    public static async Task<PagedResult<T>> ToPagedResultAsync<T>(this IQueryable<T> query, 
        int page, int pageSize, CancellationToken cancellationToken = default) where T : class
    {
        var result = new PagedResult<T>
        {
            CurrentPage = page,
            PageSize = pageSize,
            RowCount = query.Count()
        };


        var pageCount = (double)result.RowCount / pageSize;
        result.PageCount = (int)Math.Ceiling(pageCount);
 
        var skip = (page - 1) * pageSize;     
        result.Results = await query.Skip(skip).Take(pageSize).ToListAsync(cancellationToken);
 
        return result;
    }
    
    public static async Task<PagedResult<U>> ToPagedResultAsync<T, U>(this IQueryable<T> query,
        int page, int pageSize, IConfigurationProvider provider, CancellationToken cancellationToken = default) where U: class
    {
        var result = new PagedResult<U>
        {
            CurrentPage = page,
            PageSize = pageSize,
            RowCount = query.Count()
        };

        var pageCount = (double)result.RowCount / pageSize;
        result.PageCount = (int)Math.Ceiling(pageCount);
 
        var skip = (page - 1) * pageSize;
        result.Results = await query.Skip(skip)
                              .Take(pageSize)
                              .ProjectTo<U>(provider)
                              .ToListAsync(cancellationToken);
 
        return result;
    }
}