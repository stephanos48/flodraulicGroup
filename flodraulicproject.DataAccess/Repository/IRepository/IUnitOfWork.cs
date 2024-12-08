using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {

        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        ICompanyRepository Company { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IOrderDetailRepository OrderDetail { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IPartFamilyRepository PartFamily { get; }
        IInventoryRepository Inventory { get; }
        ICustomerLocationRepository CustomerLocation { get; }
        IFloLocationRepository FloLocation { get; }
        ITicketRepository Ticket { get; }
        IStatusRepository Status { get; }
        IShippedQtyRepository ShippedQty { get; }
        IFloContactRepository FloContact { get; }
        IWorkInstructionRepository WorkInstruction { get; }
        IServiceManualRepository ServiceManual { get; }
        ITimeTrackerRepository TimeTracker { get; }
        ITicketStatusRepository TicketStatus { get; }
        ILaborCodeRepository LaborCode { get; }
        ISupplierRepository Supplier { get; }
        ISupplierContactRepository SupplierContact { get; }
        ILogStatusRepository LogStatus { get; }
        IMfgLocationRepository MfgLocation { get; }
        ISalesLocationRepository SalesLocation { get; }
        IEstimatorRepository Estimator { get; }
        IEngineerRepository Engineer { get; }
        IEngineeringLogRepository EngineeringLog { get; }
        IEngLogCommentRepository EngLogComment { get; }
        IEngineeringLogImageRepository EngineeringLogImage { get; }
        IEcnLogRepository EcnLog { get; }
        IEcnLogImageRepository EcnLogImage { get; }
        IEcnLogStatusRepository EcnLogStatus { get; }
        IEcnLogCommentRepository EcnLogComment { get; }


        void Save();

    }
}
