using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Properties.Model.Entities
{
    /// <summary>
    /// Property entity
    /// </summary>
    public class Property
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyId { get; set; }

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

        public int Year { get; set; }

        public int OwnerId { get; set; }


        [ForeignKey(nameof(OwnerId))]
        public Owner Owner { get; set; }

        public IEnumerable<PropertyTrace> PropertyTraces { get; set; }


        public IEnumerable<PropertyImage> PropertyImages { get; set; }

    }
}
