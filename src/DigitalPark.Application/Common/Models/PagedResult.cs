namespace DigitalPark.Application.Common.Models;

public class PagedResult<T>
{
    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public int RowCount { get; set; }

    public int PageCount { get; set; }

    public IList<T> Results { get; set; }
}