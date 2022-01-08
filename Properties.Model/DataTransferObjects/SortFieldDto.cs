using Properties.Model.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Properties.Model.DataTransferObjects
{
    public class SortFieldDto
    {
        public string DataField { get; set; }
        public string SortOrder { get; set; }

        public static List<SortFieldDto> MapDto(string[] sorters)
        {
            var list = sorters.Select(json => json.DeserializeCaseInsensitive<SortFieldDto>()).ToList();
            return list;
        }
    }
}
