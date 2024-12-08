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
    public class EcnLogRepository : Repository<EcnLog>, IEcnLogRepository
    {
        private ApplicationDbContext _db;
        public EcnLogRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EcnLog obj)
        {
            var objFromDb = _db.EcnLogs.FirstOrDefault(e => e.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.EcnLogStatusId = obj.EcnLogStatusId;
                objFromDb.DateCreated = obj.DateCreated;
                objFromDb.CreatedBy = obj.CreatedBy;
                objFromDb.EcnRequestDate = obj.EcnRequestDate;
                objFromDb.EngineeringLogId = obj.EngineeringLogId;
                objFromDb.Reason = obj.Reason;
                objFromDb.CostImpact = obj.CostImpact;
                objFromDb.AffectPrice = obj.AffectPrice;
                objFromDb.CustomerApprovalReq = obj.CustomerApprovalReq;
                objFromDb.ECNAddlEngHrs = obj.ECNAddlEngHrs;
                objFromDb.ECNAddlShopHrs = obj.ECNAddlShopHrs;
                objFromDb.PCNAddlEngHrs = obj.PCNAddlEngHrs;
                objFromDb.PCNAddlShopHrs = obj.PCNAddlShopHrs;
                objFromDb.RespToProcess = obj.RespToProcess;
                objFromDb.EcnCompletionDate = obj.EcnCompletionDate;
                objFromDb.Notes = obj.Notes;
                objFromDb.EcnLogImages = obj.EcnLogImages;

            }
            //_db.EcnLogs.Update(obj);
        }
    }
}
