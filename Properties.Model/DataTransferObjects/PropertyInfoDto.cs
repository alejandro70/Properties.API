using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Properties.Model.DataTransferObjects
{
    public class PropertyInfoDto
    {
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerAddress { get; set; }
        public string Image { get; set; }
    }
}
