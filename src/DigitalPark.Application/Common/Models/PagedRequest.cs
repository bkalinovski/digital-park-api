namespace DigitalPark.Application.Common.Models;

public abstract class PagedRequest
{
    protected int PageNumber { get; set; }

    protected int PageSize { get; set; }
}