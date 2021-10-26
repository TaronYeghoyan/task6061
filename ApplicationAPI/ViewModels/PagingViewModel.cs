using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationAPI.ViewModels
{
    public class PagingViewModel<T> : List<T>
    {
        public int Page { get; private set; }
        public int TotalPages { get; private set; }

        public PagingViewModel(IEnumerable<T> items, int count, int Page, int PageSize)
        {
            this.Page = Page;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (Page > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (Page < TotalPages);
            }
        }

        public static PagingViewModel<T> Create(IEnumerable<T> Collection, int Page, int PageSize = 7)
        {
            var count = Collection.Count();
            var items = Collection.Skip((Page - 1) * PageSize).Take(PageSize);
            return new PagingViewModel<T>(items, count, Page, PageSize);
        }
    }
}