using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcAjaxToolkit.Pager
{
    public class PagedList<T> : List<T>, IPagedList
    {
        public PagedList(IEnumerable<T> content, int currentPage, int pageSize, int totalCount)
            : this(totalCount, currentPage, pageSize)
        {
            AddRange(content);
        }
        public PagedList(IQueryable<T> source, int currentPage, int pageSize)
            : this(source.Count(), currentPage, pageSize)
        {
            AddRange(source.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList());
        }

        public PagedList(IEnumerable<T> source, int currentPage, int pageSize)
            : this(source.Count(), currentPage, pageSize)
        {
            AddRange(source.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList());
        }

        protected PagedList(int count, int currentPage, int pageSize)
        {
            TotalCount = count;
            PageSize = Math.Max(pageSize, 1);
            CurrentPage = Math.Min(Math.Max(currentPage, 1), TotalPages);
        }

        public int CurrentPage { get; set; }

        public bool HasPreviousPage
        {
            get { return CurrentPage > 1; }
        }

        public bool HasNextPage
        {
            get { return CurrentPage < TotalPages; }
        }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages
        {
            get { return Math.Max((TotalCount + PageSize - 1) / PageSize, 1); }
        }
    }
}