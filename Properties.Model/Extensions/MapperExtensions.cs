using AutoMapper;
using Properties.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Model.Extensions
{
    public static class MapperExtensions
    {
        public static IPageResultModel<TDestination> Map<TSource, TDestination>(this IMapper mapper, IPageResultModel<TSource> pageResultSourceModel)
        {
            var list = pageResultSourceModel.Items.Select(s => mapper.Map<TSource, TDestination>(s)).ToList();
            var pageResultModel = new PageResultModel<TDestination>(list, pageResultSourceModel.PageIndex, pageResultSourceModel.PageSize, pageResultSourceModel.TotalItems);
            return pageResultModel;
        }
    }
}
