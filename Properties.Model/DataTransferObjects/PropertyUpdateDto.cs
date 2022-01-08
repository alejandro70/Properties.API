using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Properties.Model.DataTransferObjects
{
    public class PropertyUpdateDto
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [StringLength(50)]
        public string CodeInternal { get; set; }

        [Required]
        public int Year { get; set; }
        public string Image { get; set; }

        [Required]
        [StringLength(150)]
        public string OwnerName { get; set; }

        [Required]
        [StringLength(150)]
        public string OwnerAddress { get; set; }
    }
}
