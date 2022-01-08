using Microsoft.EntityFrameworkCore;
using Properties.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Model
{
    /// <summary>
    /// DbContext for DB EntityFramework class
    /// </summary>
    public class PropertiesContext : DbContext
    {
        public PropertiesContext(DbContextOptions<PropertiesContext> options) : base(options)
        {
        }

        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<PropertyImage> PropertyImage { get; set; }
        public virtual DbSet<PropertyTrace> PropertyTrace { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().HasData(
                new Owner { OwnerId = 1, Name = "www.millionandup.com", Address = "2000 Ponce de Leon Blvd #513, Coral Gables, FL 33134" }
                );

            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    PropertyId = 1,
                    Name = "BRICKELL-AVE #PH01",
                    Address = "1451 BRICKELL-AVE #PH01,MIAMI,FL 33131",
                    Price = 39500000,
                    CodeInternal = "A11108153",
                    Year = 2017,
                    OwnerId = 1
                },
                new Property
                {
                    PropertyId = 2,
                    Name = "COLLINS AVE #PH-A",
                    Address = "3315 COLLINS AVE #PH-A,MIAMI BEACH,FL 33140",
                    Price = 34950000,
                    CodeInternal = "A11016058",
                    Year = 2015,
                    OwnerId = 1
                }
               );

            modelBuilder.Entity<PropertyImage>().HasData(
                new PropertyImage { PropertyImageId = 1, PropertyId = 1, File = "https://millionandupprod.blob.core.windows.net/mls/resize/363144808_1-352X336.jpg", Enabled = true },
                new PropertyImage { PropertyImageId = 2, PropertyId = 2, File = "https://millionandupprod.blob.core.windows.net/mls/resize/356973807_1-352X336.jpg", Enabled = true });

        }
    }
}
