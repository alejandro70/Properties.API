using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Properties.Data.Entities
{
    public class PropertyTrace
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyTraceId { get; set; }

        public int PropertyId { get; set; }

        [Required]
        public DateTime DateSale { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public double Value { get; set; }

        public double Tax { get; set; }


        [ForeignKey(nameof(PropertyId))]
        public Property Property { get; set; }
    }
}
