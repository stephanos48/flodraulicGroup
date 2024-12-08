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
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<PartFamily> PartFamilies { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<CustomerLocation> CustomerLocations { get; set; }
        public DbSet<FloLocation> FloLocations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<ShippedQty> ShippedQtys { get; set; }
        public DbSet<FloContact> FloContacts { get; set; }
        public DbSet<LaborCode> LaborCodes { get; set; }
        public DbSet<TimeTracker> TimeTrackers { get; set; }
        public DbSet<WorkInstruction> WorkInstructions { get; set; }
        public DbSet<ServiceManual> ServiceManuals { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierContact> SupplierContacts { get; set; }
        public DbSet<LogStatus> LogStatuses { get; set; }
        public DbSet<MfgLocation> MfgLocations { get; set; }
        public DbSet<SalesLocation> SalesLocations { get; set; }
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Estimator> Estimators { get; set; }
        public DbSet<EngineeringLog> EngineeringLogs { get; set; }
        public DbSet<EngLogComment> EngLogComments { get; set; }
        public DbSet<EngineeringLogImage> EngineeringLogImages { get; set; }
        public DbSet<EcnLog> EcnLogs { get; set; }
        public DbSet<EcnLogImage> EcnLogImages { get; set; }
        public DbSet<EcnLogComment> EcnLogComments { get; set; }
        public DbSet<EcnLogStatus> EcnLogStatuses { get; set; }
        public DbSet<Hotlist> Hotlists { get; set; }
        public DbSet<HotlistImage> HotlistImages { get; set; }
        public DbSet<HotlistComment> HotlistComments { get; set; }
        public DbSet<HotlistStatus> HotlistStatuses { get; set; }
        public DbSet<IssueCategory> IssueCategories { get; set; }
        public DbSet<HotlistResp> HotlistResps { get; set; }
        public DbSet<InitialQuoteReview> InitialQuoteReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //need this line when you add identity
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<LogStatus>().HasData(
	            new LogStatus { LogStatusId = 1, LogStatusName = "A. Project Queue", Notes = "" },
	            new LogStatus { LogStatusId = 2, LogStatusName = "B. Quote Feasibility Review", Notes = "" },
	            new LogStatus { LogStatusId = 3, LogStatusName = "C. Preparing Quote", Notes = "" },
	            new LogStatus { LogStatusId = 4, LogStatusName = "D. Review Quote w/ Paul", Notes = "" },
	            new LogStatus { LogStatusId = 5, LogStatusName = "E. Sent Quote to Customer / Awaiting Decision", Notes = "" },
				new LogStatus { LogStatusId = 6, LogStatusName = "F. Order Received / Eng Kick Off", Notes = "" },
				new LogStatus { LogStatusId = 7, LogStatusName = "G. Managerial Approval for Quotes above $50K", Notes = "" },
				new LogStatus { LogStatusId = 8, LogStatusName = "H. Engineering Design", Notes = "" },
				new LogStatus { LogStatusId = 9, LogStatusName = "I. Design Sent to Customer for Approval", Notes = "" },
				new LogStatus { LogStatusId = 10, LogStatusName = "J. Approved / Ready for Shop Release", Notes = "" },
				new LogStatus { LogStatusId = 11, LogStatusName = "K. Shop Released / Waiting for Parts", Notes = "" },
				new LogStatus { LogStatusId = 12, LogStatusName = "L. All Parts in Stock / Waiting to go to Assy", Notes = "" },
				new LogStatus { LogStatusId = 13, LogStatusName = "M. Assembly & Test", Notes = "" },
				new LogStatus { LogStatusId = 14, LogStatusName = "N. Shipping", Notes = "" },
				new LogStatus { LogStatusId = 15, LogStatusName = "O. Documentation / Manual Done", Notes = "" },
				new LogStatus { LogStatusId = 16, LogStatusName = "P. Completed Projects / Product Delivered", Notes = "" },
				new LogStatus { LogStatusId = 17, LogStatusName = "Q. No Quote / Quote Archived", Notes = "" },
				new LogStatus { LogStatusId = 18, LogStatusName = "R. On Hold", Notes = "" }
				);

			modelBuilder.Entity<Engineer>().HasData(
                new Engineer { Id = 1, EngineerName = "Anthony Bizon", Notes ="", ImageUrl="" },
				new Engineer { Id = 2, EngineerName = "Brian Paxton", Notes = "", ImageUrl = "" },
				new Engineer { Id = 3, EngineerName = "Chris Dewandeler", Notes = "", ImageUrl = "" },
				new Engineer { Id = 4, EngineerName = "Chris Johnson", Notes = "", ImageUrl = "" },
				new Engineer { Id = 5, EngineerName = "Chris Walker", Notes = "", ImageUrl = "" },
				new Engineer { Id = 6, EngineerName = "Darren Zielke", Notes = "", ImageUrl = "" },
				new Engineer { Id = 7, EngineerName = "David Bucek", Notes = "", ImageUrl = "" },
				new Engineer { Id = 8, EngineerName = "Daymon Shear", Notes = "", ImageUrl = "" },
				new Engineer { Id = 9, EngineerName = "Derrick Herr", Notes = "", ImageUrl = "" },
				new Engineer { Id = 10, EngineerName = "Dylan Smith", Notes = "", ImageUrl = "" },
				new Engineer { Id = 11, EngineerName = "Kyle Swindlehurst", Notes = "", ImageUrl = "" },
				new Engineer { Id = 12, EngineerName = "Paul Brown", Notes = "", ImageUrl = "" },
				new Engineer { Id = 13, EngineerName = "Phil Kimberlin", Notes = "", ImageUrl = "" },
				new Engineer { Id = 14, EngineerName = "Randy Brown", Notes = "", ImageUrl = "" },
				new Engineer { Id = 15, EngineerName = "Scott Tidwell", Notes = "", ImageUrl = "" },
				new Engineer { Id = 16, EngineerName = "Dylan Smith", Notes = "", ImageUrl = "" },
				new Engineer { Id = 17, EngineerName = "Gaylynn Fisher", Notes = "", ImageUrl = "" },
				new Engineer { Id = 18, EngineerName = "Frank Edwards", Notes = "", ImageUrl = "" },
				new Engineer { Id = 19, EngineerName = "Joe Marshall", Notes = "", ImageUrl = "" },
				new Engineer { Id = 20, EngineerName = "Pat Laake", Notes = "", ImageUrl = "" },
				new Engineer { Id = 21, EngineerName = "Pending", Notes = "", ImageUrl = "" }
				);

			modelBuilder.Entity<Estimator>().HasData(
	            new Estimator { Id = 1, EstimatorName = "Chris Walker", Notes = "" },
	            new Estimator { Id = 2, EstimatorName = "Derrick Herr", Notes = "" },
	            new Estimator { Id = 3, EstimatorName = "Frank Edwards", Notes = "" },
	            new Estimator { Id = 4, EstimatorName = "Jeff Pogue", Notes = "" },
	            new Estimator { Id = 5, EstimatorName = "Joe Sorano", Notes = "" },
	            new Estimator { Id = 6, EstimatorName = "Kyle Swindlehurst", Notes = "" },
	            new Estimator { Id = 7, EstimatorName = "Noelle Sorano", Notes = "" },
	            new Estimator { Id = 8, EstimatorName = "Pat Laake", Notes = "" },
	            new Estimator { Id = 9, EstimatorName = "Paul Brown", Notes = "" },
	            new Estimator { Id = 10, EstimatorName = "Joe Marshall", Notes = "" },
	            new Estimator { Id = 11, EstimatorName = "John Reed", Notes = "" },
	            new Estimator { Id = 12, EstimatorName = "John Voss", Notes = "" },
	            new Estimator { Id = 13, EstimatorName = "John Wheelock", Notes = "" },
	            new Estimator { Id = 14, EstimatorName = "Scott Tidwell", Notes = "" },
	            new Estimator { Id = 15, EstimatorName = "Scott Williams", Notes = "" },
	            new Estimator { Id = 16, EstimatorName = "Theresa Schmittling", Notes = "" },
	            new Estimator { Id = 17, EstimatorName = "Dave Bucek", Notes = "" },
	            new Estimator { Id = 18, EstimatorName = "Inside Sales", Notes = "" },
	            new Estimator { Id = 19, EstimatorName = "Unknown", Notes = "" }
	            );

            modelBuilder.Entity<EcnLogStatus>().HasData(
                new EcnLogStatus { EcnLogStatusId = 1, StatusName = "New", Notes = "" },
                new EcnLogStatus { EcnLogStatusId = 2, StatusName = "In Process", Notes = "" },
                new EcnLogStatus { EcnLogStatusId = 3, StatusName = "Complete", Notes = "" }
                );

            modelBuilder.Entity<HotlistStatus>().HasData(
                new HotlistStatus { HotlistStatusId = 1, StatusName = "New", Notes = "" },
                new HotlistStatus { HotlistStatusId = 2, StatusName = "In Process", Notes = "" },
                new HotlistStatus { HotlistStatusId = 3, StatusName = "Complete", Notes = "" }
                );

            modelBuilder.Entity<IssueCategory>().HasData(
                new IssueCategory { IssueCategoryId = 1, CategoryName = "Design Issue", Notes = "" },
                new IssueCategory { IssueCategoryId = 2, CategoryName = "Drawing Creation Issue", Notes = "" },
                new IssueCategory { IssueCategoryId = 3, CategoryName = "Part Damaged in Ops", Notes = "" },
                new IssueCategory { IssueCategoryId = 4, CategoryName = "Parts Purchased Incorrectly", Notes = "" },
                new IssueCategory { IssueCategoryId = 5, CategoryName = "Parts Not Purchased In Time", Notes = "" },
                new IssueCategory { IssueCategoryId = 6, CategoryName = "Need Job Moved Up for Production", Notes = "" }
                );

            modelBuilder.Entity<HotlistResp>().HasData(
                new HotlistResp { HotlistRespId = 1, RespName = "Supplier", Notes = "" },
                new HotlistResp { HotlistRespId = 2, RespName = "Purchasing", Notes = "" },
                new HotlistResp { HotlistRespId = 3, RespName = "Engineering", Notes = "" },
                new HotlistResp { HotlistRespId = 4, RespName = "Operations", Notes = "" },
                new HotlistResp { HotlistRespId = 5, RespName = "Other", Notes = "" }
                );

            modelBuilder.Entity<MfgLocation>().HasData(
                new MfgLocation { Id = 1, MfgLocationName = "Columbus", Notes = "" },
                new MfgLocation { Id = 2, MfgLocationName = "Westland", Notes = "" },
                new MfgLocation { Id = 3, MfgLocationName = "Indy", Notes = "" },
                new MfgLocation { Id = 4, MfgLocationName = "Norcross", Notes = "" },
                new MfgLocation { Id = 5, MfgLocationName = "Braselton", Notes = "" }
                );

            modelBuilder.Entity<SalesLocation>().HasData(
                new SalesLocation { Id = 1, SalesLocationName = "Brea", Notes = "" },
                new SalesLocation { Id = 2, SalesLocationName = "Columbus", Notes = "" },
                new SalesLocation { Id = 3, SalesLocationName = "Indy", Notes = "" },
                new SalesLocation { Id = 4, SalesLocationName = "Norcross", Notes = "" },
                new SalesLocation { Id = 5, SalesLocationName = "Westland", Notes = "" },
                new SalesLocation { Id = 6, SalesLocationName = "NAHI", Notes = "" },
                new SalesLocation { Id = 7, SalesLocationName = "Grand Rapids", Notes = "" },
                new SalesLocation { Id = 8, SalesLocationName = "Houston", Notes = "" },
                new SalesLocation { Id = 9, SalesLocationName = "Braselton", Notes = "" }
                );

            modelBuilder.Entity<LaborCode>().HasData(
	            new LaborCode { LaborCodeId = 1, LaborCodeName = "001", Notes = "Std Engineering Work on Project" },
	            new LaborCode { LaborCodeId = 2, LaborCodeName = "050", Notes = "First Time Test" },
	            new LaborCode { LaborCodeId = 3, LaborCodeName = "310", Notes = "Engineering Rework due to Vendor Error" },
				new LaborCode { LaborCodeId = 4, LaborCodeName = "410", Notes = "Engineering Rework due to Eng Error" },
				new LaborCode { LaborCodeId = 5, LaborCodeName = "460", Notes = "Engineering Rework due to Customer Change" },
				new LaborCode { LaborCodeId = 6, LaborCodeName = "500", Notes = "Engineering Sales Support" },
				new LaborCode { LaborCodeId = 7, LaborCodeName = "550", Notes = "PTO" },
				new LaborCode { LaborCodeId = 8, LaborCodeName = "OHNC", Notes = "Overhead Not Chargeable" },
				new LaborCode { LaborCodeId = 9, LaborCodeName = "Manuals", Notes = "" },
				new LaborCode { LaborCodeId = 10, LaborCodeName = "Redlines", Notes = "" },
				new LaborCode { LaborCodeId = 11, LaborCodeName = "Quotes", Notes = "" }
				);

            modelBuilder.Entity<FloLocation>().HasData(
                new FloLocation { FloLocationId = 1, LocationName = "ATL", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new FloLocation { FloLocationId = 2, LocationName = "DFW", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new FloLocation { FloLocationId = 3, LocationName = "WA", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new FloLocation { FloLocationId = 4, LocationName = "BUFFALO", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new FloLocation { FloLocationId = 5, LocationName = "HOUSTON", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new FloLocation { FloLocationId = 6, LocationName = "WESTLAND", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new FloLocation { FloLocationId = 7, LocationName = "COLUMBUS", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new FloLocation { FloLocationId = 8, LocationName = "BATON ROUGE", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new FloLocation { FloLocationId = 9, LocationName = "BREA", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new FloLocation { FloLocationId = 10, LocationName = "GRAND RAPIDS", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new FloLocation { FloLocationId = 11, LocationName = "GREENFIELD", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new FloLocation { FloLocationId = 12, LocationName = "GILMORE", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new FloLocation { FloLocationId = 13, LocationName = "NAHI", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new FloLocation { FloLocationId = 14, LocationName = "NORCROSS", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new FloLocation { FloLocationId = 15, LocationName = "TEMPE", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" }
                );

            modelBuilder.Entity<FloContact>().HasData(
                new FloContact { Id = 1, Email = "stephen.english@me.com", FloLocationId = 1, Name = "Stephen English", Notes = "" },
                new FloContact { Id = 2, Email = "trobbins@gmail.com", FloLocationId = 2, Name = "Tim Robbins", Notes = "" },
                new FloContact { Id = 3, Email = "henglish@gmail.com", FloLocationId = 3, Name = "Helen English", Notes = "" }
                );



            modelBuilder.Entity<CustomerLocation>().HasData(
                new CustomerLocation { CustomerLocationId = 1, LocationName = "ATL", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new CustomerLocation { CustomerLocationId = 2, LocationName = "DFW", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" },
                new CustomerLocation { CustomerLocationId = 3, LocationName = "HOU", Address = "", City = "", State = "", ZipCode = "", Country = "", Notes = "" }
                );

            modelBuilder.Entity<TicketStatus>().HasData(
                new TicketStatus { TicketStatusId = 1, StatusName = "New", Notes = "" },
                new TicketStatus { TicketStatusId = 2, StatusName = "In Process", Notes = "" },
                new TicketStatus { TicketStatusId = 3, StatusName = "Complete", Notes = "" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Pumps", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Valves", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Filters", DisplayOrder = 3 }
                );

            modelBuilder.Entity<PartFamily>().HasData(
                new PartFamily { Id = 1, FamilyName = "Tractor", DisplayOrder = 1 },
                new PartFamily { Id = 2, FamilyName = "Trailer", DisplayOrder = 2 }
                );

            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, StatusName = "NewOrder", Notes = "" },
                new Status { StatusId = 2, StatusName = "P21Entered", Notes = "" },
                new Status { StatusId = 3, StatusName = "Shipped/Invoiced", Notes = "" },
                new Status { StatusId = 4, StatusName = "Paid", Notes = "" },
                new Status { StatusId = 5, StatusName = "Canceled", Notes = "" }
                );

            modelBuilder.Entity<ShippedQty>().HasData(
                new ShippedQty { Id = 1, ProductId = 1, FloLocationId = 1, QtyShipped = 10, OrderNoId = 1021 },
                new ShippedQty { Id = 2, ProductId = 2, FloLocationId = 2, QtyShipped = 20, OrderNoId = 1022 },
                new ShippedQty { Id = 3, ProductId = 3, FloLocationId = 3, QtyShipped = 10, OrderNoId = 1023 }
                );

            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { Id = 1, ProductId = 1, StartQoh = 1, FloLocationId = 1 },
                new Inventory { Id = 2, ProductId = 2, StartQoh = 10, FloLocationId = 2 },
                new Inventory { Id = 3, ProductId = 3, StartQoh = 0 , FloLocationId = 3 }
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
                    LeadTime = 14,
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
                    LeadTime = 14,
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
                    LeadTime = 14,
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
                    LeadTime = 14,
                    CategoryId = 3,
                    PartFamilyId = 1,
                    ImageUrl = ""
                }
            );
        }
    }
}
