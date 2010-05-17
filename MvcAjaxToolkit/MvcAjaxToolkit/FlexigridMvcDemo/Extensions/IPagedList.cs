using System.Collections;

namespace MvcAjaxToolkit
{
    public interface IPagedList : IEnumerable
    {
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        int TotalPages { get; }
        int CurrentPage { get; set; }
        int PageSize { get; set; }
        int TotalCount { get; set; }
    } 
}