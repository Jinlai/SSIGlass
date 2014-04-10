using System;
using System.Collections.Generic;

namespace SSIGlass.Contract
{ 
    public class PagingResult<T>
    {
        public PagingResult(IEnumerable<T> items)
        {
            Items = items != null ? new List<T>(items) : new List<T>();
        }

        public int PageSize { get; set; }

        public int TotalItems { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get
            {
                if (TotalItems <= 0)                
                    return 0;
                
                return (int)Math.Ceiling((decimal)TotalItems / PageSize);
            }
        }

        public ICollection<T> Items { get; set; }
    }
}
