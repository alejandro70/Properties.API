using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Model.Models
{
    public class PageResultModel<T> : IPageResultModel<T>
    {
        public IEnumerable<T> Items
        {
            get
            {
                return JustDecompileGenerated_get_Items();
            }
            set
            {
                JustDecompileGenerated_set_Items(value);
            }
        }

        private IEnumerable<T> JustDecompileGenerated_Items_k__BackingField;

        public IEnumerable<T> JustDecompileGenerated_get_Items()
        {
            return this.JustDecompileGenerated_Items_k__BackingField;
        }

        private void JustDecompileGenerated_set_Items(IEnumerable<T> value)
        {
            this.JustDecompileGenerated_Items_k__BackingField = value;
        }

        public int PageIndex
        {
            get
            {
                return JustDecompileGenerated_get_PageIndex();
            }
            set
            {
                JustDecompileGenerated_set_PageIndex(value);
            }
        }

        private int JustDecompileGenerated_PageIndex_k__BackingField;

        public int JustDecompileGenerated_get_PageIndex()
        {
            return this.JustDecompileGenerated_PageIndex_k__BackingField;
        }

        private void JustDecompileGenerated_set_PageIndex(int value)
        {
            this.JustDecompileGenerated_PageIndex_k__BackingField = value;
        }

        public int PageSize
        {
            get
            {
                return JustDecompileGenerated_get_PageSize();
            }
            set
            {
                JustDecompileGenerated_set_PageSize(value);
            }
        }

        private int JustDecompileGenerated_PageSize_k__BackingField;

        public int JustDecompileGenerated_get_PageSize()
        {
            return this.JustDecompileGenerated_PageSize_k__BackingField;
        }

        private void JustDecompileGenerated_set_PageSize(int value)
        {
            this.JustDecompileGenerated_PageSize_k__BackingField = value;
        }

        public int TotalItems
        {
            get
            {
                return JustDecompileGenerated_get_TotalItems();
            }
            set
            {
                JustDecompileGenerated_set_TotalItems(value);
            }
        }

        private int JustDecompileGenerated_TotalItems_k__BackingField;

        public int JustDecompileGenerated_get_TotalItems()
        {
            return this.JustDecompileGenerated_TotalItems_k__BackingField;
        }

        private void JustDecompileGenerated_set_TotalItems(int value)
        {
            this.JustDecompileGenerated_TotalItems_k__BackingField = value;
        }

        public int TotalPages
        {
            get
            {
                return JustDecompileGenerated_get_TotalPages();
            }
            set
            {
                JustDecompileGenerated_set_TotalPages(value);
            }
        }

        private int JustDecompileGenerated_TotalPages_k__BackingField;

        public int JustDecompileGenerated_get_TotalPages()
        {
            return this.JustDecompileGenerated_TotalPages_k__BackingField;
        }

        private void JustDecompileGenerated_set_TotalPages(int value)
        {
            this.JustDecompileGenerated_TotalPages_k__BackingField = value;
        }

        public PageResultModel()
        {
            this.PageIndex = 0;
            this.PageSize = 0;
            this.TotalPages = 0;
            this.TotalItems = 0;
            this.Items = new List<T>();
        }

        public PageResultModel(IEnumerable<T> items)
        {
            this.PageIndex = 0;
            this.PageSize = Enumerable.Count<T>(items);
            this.TotalPages = 1;
            this.TotalItems = Enumerable.Count<T>(items);
            this.Items = items;
        }

        public PageResultModel(IEnumerable<T> items, int pageIndex, int pageSize, int totalItems)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalPages = Convert.ToInt32(Math.Ceiling((double)totalItems / (double)pageSize));
            this.TotalItems = totalItems;
            this.Items = items;
        }
    }
}
