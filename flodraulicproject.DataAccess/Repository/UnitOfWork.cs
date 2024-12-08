using flodraulicproject.DataAccess.Data;
using flodraulicproject.DataAccess.Repository.IRepository;
using flodraulicproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IProductRepository Product { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public IPartFamilyRepository PartFamily { get; private set; }
        public IInventoryRepository Inventory { get; private set; }
        public ICustomerLocationRepository CustomerLocation { get; private set; }
        public IFloLocationRepository FloLocation { get; private set; }
        public ITicketRepository Ticket { get; private set; }
        public IStatusRepository Status { get; private set; }
        public IShippedQtyRepository ShippedQty { get; private set; }
        public IFloContactRepository FloContact { get; private set; }
        public IWorkInstructionRepository WorkInstruction { get; private set; }
        public IServiceManualRepository ServiceManual { get; private set; }
        public ITicketStatusRepository TicketStatus { get; private set; }
        public ITimeTrackerRepository TimeTracker { get; private set; }
        public ILaborCodeRepository LaborCode { get; private set; }
        public ISupplierRepository Supplier { get; private set; }
        public ISupplierContactRepository SupplierContact { get; private set; }
        public IMfgLocationRepository MfgLocation { get; private set; }
        public ISalesLocationRepository SalesLocation { get; private set; }
        public IEngineerRepository Engineer { get; private set; }
        public IEstimatorRepository Estimator { get; private set; }
        public ILogStatusRepository LogStatus { get; private set; }
        public IEngineeringLogRepository EngineeringLog { get; private set; }
        public IEngLogCommentRepository EngLogComment { get; private set; }
        public IEngineeringLogImageRepository EngineeringLogImage { get; private set; }
        public IEcnLogRepository EcnLog { get; private set; }
        public IEcnLogImageRepository EcnLogImage { get; private set; }
        public IEcnLogCommentRepository EcnLogComment { get; private set; }
        public IEcnLogStatusRepository EcnLogStatus { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetail = new OrderDetailRepository(_db);
            PartFamily = new PartFamilyRepository(_db);
            Inventory = new InventoryRepository(_db);
            CustomerLocation = new CustomerLocationRepository(_db);
            FloLocation = new FloLocationRepository(_db);
            Ticket = new TicketRepository(_db);
            Status = new StatusRepository(_db);
            ShippedQty = new ShippedQtyRepository(_db);
            FloContact = new FloContactRepository(_db);
            WorkInstruction = new WorkInstructionRepository(_db);
            ServiceManual = new ServiceManualRepository(_db);
            TicketStatus = new TicketStatusRepository(_db);
            TimeTracker = new TimeTrackerRepository(_db);
            LaborCode = new LaborCodeRepository(_db);
            Supplier = new SupplierRepository(_db);
            SupplierContact = new SupplierContactRepository(_db);
            LogStatus = new LogStatusRepository(_db);
            MfgLocation = new MfgLocationRepository(_db);
            SalesLocation = new SalesLocationRepository(_db);
            Engineer = new EngineerRepository(_db);
            Estimator = new EstimatorRepository(_db);
            EngineeringLog = new EngineeringLogRepository(_db);
            EngLogComment = new EngLogCommentRepository(_db);
            EngineeringLogImage = new EngineeringLogImageRepository(_db);
            EcnLog = new EcnLogRepository(_db);
            EcnLogImage = new EcnLogImageRepository(_db);
            EcnLogComment = new EcnLogCommentRepository(_db);
            EcnLogStatus = new EcnLogStatusRepository(_db);

        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
