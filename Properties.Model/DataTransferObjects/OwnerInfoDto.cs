using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Model.DataTransferObjects
{
    public class OwnerInfoDto
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
