using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Helpers
{
    public class PagingList<T>:List<T>
    {
        public PagingList(IEnumerable<T> items, int pageNumber,  int pageSize, int count)
        {
            CurrentPage = pageNumber;
            TotalPage = (int) Math.Ceiling(count/ (double) pageSize);
            PageSize = pageSize;
            TotalCount = count;
            AddRange(items);
        }

        public int CurrentPage { get; set; } 
       public int TotalPage { get; set; }
       public int PageSize { get; set; }
       public int TotalCount { get; set; }
       public static async Task<PagingList<T>> CreatAsync(IQueryable<T> source,int pageNumber, int pageSize)
       {
           var count = await source.CountAsync();
           var items = await source.Skip((pageNumber - 1)* pageSize)
                                   .Take(pageSize).ToListAsync();
            return new PagingList<T>(items,pageNumber,pageSize,count);

       } 
    }
}