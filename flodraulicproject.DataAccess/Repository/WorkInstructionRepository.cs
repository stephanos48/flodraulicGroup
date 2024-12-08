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
    public class WorkInstructionRepository : Repository<WorkInstruction>, IWorkInstructionRepository
    {
        private ApplicationDbContext _db;
        public WorkInstructionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(WorkInstruction obj)
        {
            var objFromDb = _db.WorkInstructions.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.WIName = obj.WIName;
                objFromDb.WIType = obj.WIType;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
