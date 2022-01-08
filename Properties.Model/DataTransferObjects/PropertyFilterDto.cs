using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Model.DataTransferObjects
{
    public class PropertyFilterDto
    { 
        public string Name { get; set; }
        public string Address { get; set; }
        public double? Price { get; set; }
        public string CodeInternal { get; set; }
        public int? Year { get; set; }
        public int? OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
