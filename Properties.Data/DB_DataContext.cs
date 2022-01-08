using Microsoft.EntityFrameworkCore;
using Properties.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Data
{
    public class DB_DataContext : DbContext
    {
        public DB_DataContext(DbContextOptions<DB_DataContext> options) : base(options)
        {
        }

        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
    }
}
