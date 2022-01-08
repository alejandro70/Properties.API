using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Model.Models
{
    public interface IPageResultModel<T>
    {
        IEnumerable<T> Items
        {
            get;
        }

        int PageIndex
        {
            get;
        }

        int PageSize
        {
            get;
        }

        int TotalItems
        {
            get;
        }

        int TotalPages
        {
            get;
        }
    }
}
