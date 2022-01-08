using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Properties.Model.DataTransferObjects
{
    public class PropertyImageInfoDto
    {
        public int PropertyImageId { get; set; }
        public int PropertyId { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }
    }
}
