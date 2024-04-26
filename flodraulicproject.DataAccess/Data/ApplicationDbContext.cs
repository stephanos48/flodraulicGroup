using flodraulicproject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace flodraulicproject.DataAccess.Data
{
    //public class ApplicationDbContext : DbContext
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails{ get; set; }
        public DbSet<PartFamily> PartFamilies { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<CustomerLocation> CustomerLocations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //need this line when you add identity
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Pumps", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Valves", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Filters", DisplayOrder = 3 }
                );

            modelBuilder.Entity<PartFamily>().HasData(
                new PartFamily { Id = 1, FamilyName = "Tractor", DisplayOrder = 1 },
                new PartFamily { Id = 2, FamilyName = "Trailer", DisplayOrder = 2 }
                );

            modelBuilder.Entity<CustomerLocation>().HasData(
                new CustomerLocation { CustomerLocationId = 1, LocationName = "ATL", Address = "", City = "", State ="", ZipCode = "", Country = "", Notes = "" },
                new CustomerLocation { CustomerLocationId = 2, LocationName = "DFW", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new CustomerLocation { CustomerLocationId = 3, LocationName = "HOU", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" }
                );

            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { Id = 1, PartNumber = "2000-3900", StartQoh = 1 },
                new Inventory { Id = 2, PartNumber = "219-2370", StartQoh = 10 },
                new Inventory { Id = 3, PartNumber = "031-6450", StartQoh = 0 },
                new Inventory { Id = 4, PartNumber = "222-6780", StartQoh = 4 }
                );

            modelBuilder.Entity<Company>().HasData(
                new Company { 
                    Id = 1, 
                    Name = "Matheson", 
                    StreetAddress = "124 Tech Dr", 
                    City="Tech City",
                    State="IL",
                    PostalCode = "12121",
                    PhoneNumber ="6695446789"
                },
                new Company
                {
                    Id = 2,
                    Name = "Refuse Supply",
                    StreetAddress = "126 Walawalla Dr",
                    City = "Killua",
                    State = "WA",
                    PostalCode = "12121",
                    PhoneNumber = "6695446789"
                },
                new Company
                {
                    Id = 3,
                    Name = "United Fellows",
                    StreetAddress = "124 Africa Dr",
                    City = "Memphis",
                    State = "TN",
                    PostalCode = "66121",
                    PhoneNumber = "6695446789"
                }
                );

            modelBuilder.Entity<Product>().HasData(
               new Product { 
                    Id = 1,
                    PartNumber = "2000-3900",
                    Description = "Pump",
                    ListPrice = 99,
                    Qoh = 5,
                    CategoryId = 1,
                    PartFamilyId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 2,
                    PartNumber = "219-2370",
                    Description = "Pump",
                    ListPrice = 40,
                    Qoh = 10,
                    CategoryId = 1,
                    PartFamilyId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    PartNumber = "031-6450",
                    Description = "Valve",
                    ListPrice = 55,
                    Qoh = 15,
                    CategoryId = 2,
                    PartFamilyId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 4,
                    PartNumber = "222-6780",
                    Description = "Filter",
                    ListPrice = 70,
                    Qoh = 3,
                    CategoryId = 3,
                    PartFamilyId = 1,
                    ImageUrl = ""
                }
                    );
            }

    }
}
