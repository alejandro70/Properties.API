using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Properties.Model.DataTransferObjects
{
    public class PropertyTraceInfoDto
    {
        public int PropertyTraceId { get; set; }
        public int PropertyId { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
    }
}
