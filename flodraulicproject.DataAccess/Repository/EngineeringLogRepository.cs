using flodraulicproject.DataAccess.Data;
using flodraulicproject.DataAccess.Repository.IRepository;
using flodraulicproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.DataAccess.Repository
{
    public class EngineeringLogRepository : Repository<EngineeringLog>, IEngineeringLogRepository
    {
        private ApplicationDbContext _db;
        public EngineeringLogRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EngineeringLog obj)
        {
            _db.EngineeringLogs.Update(obj);
        }

        /*public void Update(EngineeringLog obj)
        {
            var objFromDb = _db.EngineeringLogs.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.CreatedBy = obj.CreatedBy;
                objFromDb.DateCreated = obj.DateCreated;
                objFromDb.LastModifiedBy = obj.LastModifiedBy;
                objFromDb.DateModified = DateTime.Now;
                objFromDb.LogStatusId = obj.LogStatusId;
                objFromDb.EngineerId = obj.EngineerId;
                objFromDb.EstimatorId = obj.EstimatorId;
                objFromDb.MfgLocationId = obj.MfgLocationId;
                objFromDb.SalesLocationId = obj.SalesLocationId;
                objFromDb.JobNumber = obj.JobNumber;
                objFromDb.Customer = obj.Customer;
                objFromDb.SystemDescription = obj.SystemDescription;
                objFromDb.QuoteNo = obj.QuoteNo;
                objFromDb.HistoricQuoteNo = obj.HistoricQuoteNo;
                objFromDb.SalesPerson = obj.SalesPerson;
                objFromDb.Qty = obj.Qty;
                objFromDb.QuoteTargetDate = obj.QuoteTargetDate;
                objFromDb.QuoteDate = obj.QuoteDate;
                objFromDb.InitialQuoteReviewTargetDate = obj.InitialQuoteReviewTargetDate;
                objFromDb.InitialQuoteReviewDate = obj.InitialQuoteReviewDate;
                objFromDb.FinalQuoteReviewTargetDate = obj.FinalQuoteReviewDate;
                objFromDb.FinalQuoteReviewDate = obj.FinalQuoteReviewDate;
                objFromDb.OrderDate = obj.OrderDate;
                objFromDb.CustomerPoNo = obj.CustomerPoNo;
                objFromDb.PromiseDate = obj.PromiseDate;
                objFromDb.MIPTargetDate = obj.MIPTargetDate;
                objFromDb.MIPDate = obj.MIPDate;
                objFromDb.ContractReviewTargetDate = obj.ContractReviewTargetDate;
                objFromDb.ContractReviewDate = obj.ContractReviewDate;
                objFromDb.OrderEntryTargetDate = obj.OrderEntryDate;
                objFromDb.OrderEntryDate = obj.OrderEntryDate;
                objFromDb.KickOffTargetDate = obj.KickOffTargetDate;
                objFromDb.KickOffDate = obj.KickOffDate;
                objFromDb.FinancialReviewTargetDate = obj.FinancialReviewTargetDate;
                objFromDb.FinancialReviewDate = obj.FinancialReviewDate;
                objFromDb.InitialDesignReviewTargetDate = obj.InitialDesignReviewTargetDate;
                objFromDb.InitialDesignReviewDate = obj.InitialDesignReviewDate;
                objFromDb.FinalDesignReviewTargetDate= obj.FinalDesignReviewTargetDate;
                objFromDb.FinalDesignReviewDate = obj.FinalDesignReviewDate;
                objFromDb.ShopReleaseTargetDate = obj.ShopReleaseTargetDate;
                objFromDb.ShopReleaseDate = obj.ShopReleaseDate;
                objFromDb.RedlineNeeded = obj.RedlineNeeded;
                objFromDb.RedlineCompletionDate = obj.RedlineCompletionDate;
                objFromDb.QuotedEngHrs = obj.QuotedEngHrs;
                objFromDb.QuotedShopHrs = obj.QuotedShopHrs;
                objFromDb.ActualEngHrs = obj.ActualEngHrs;
                objFromDb.ActualShopHrs = obj.ActualShopHrs;
                objFromDb.EngEff = obj.EngEff;
                objFromDb.ShopEff = obj.ShopEff;
                objFromDb.TotalCost = obj.TotalCost;
                objFromDb.QuoteValue = obj.QuoteValue;
                objFromDb.ActualShipDate = obj.ActualShipDate;
                objFromDb.QuotedOT = obj.QuotedOT;
                objFromDb.MIPOT = obj.MIPOT;
                objFromDb.DesignOT = obj.DesignOT;
                objFromDb.ShipOT = obj.ShipOT;
                objFromDb.Notes = obj.Notes;
            }
            _db.EngineeringLogs.Update(obj);
        }*/
    }
}
