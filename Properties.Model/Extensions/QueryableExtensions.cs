using Microsoft.EntityFrameworkCore;
using Properties.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Properties.Model.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<IPageResultModel<T>> GetPageAsync<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            IPageResultModel<T> pageResultModel;
            IQueryable<T> queryable = query;
            IQueryable<int> queryable1 = Queryable.Select<T, int>(queryable, (T s) => 1);
            CancellationToken cancellationToken = new CancellationToken();
            int num = await EntityFrameworkQueryableExtensions.CountAsync<int>(queryable1, cancellationToken);
            if (num <= 0)
            {
                pageResultModel = new PageResultModel<T>(new List<T>(), pageIndex, pageSize, 0);
            }
            else
            {
                IQueryable<T> queryable2 = Queryable.Take<T>(Queryable.Skip<T>(query, pageIndex * pageSize), pageSize);
                cancellationToken = new CancellationToken();
                List<T> listAsync = await EntityFrameworkQueryableExtensions.ToListAsync<T>(queryable2, cancellationToken);
                List<T> list = listAsync;
                listAsync = null;
                pageResultModel = new PageResultModel<T>(list, pageIndex, pageSize, num);
            }
            return pageResultModel;
        }
    }
}
