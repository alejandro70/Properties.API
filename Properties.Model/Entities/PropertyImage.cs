using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Properties.Model.Entities
{
    /// <summary>
    /// Property image entity.
    /// </summary>
    public class PropertyImage
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyImageId { get; set; }

        public int PropertyId { get; set; }

        [Required]
        public string File { get; set; }

        public bool Enabled { get; set; }


        [ForeignKey(nameof(PropertyId))]
        public Property Property { get; set; }
    }
}
