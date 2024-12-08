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
    public class EcnLogStatusRepository : Repository<EcnLogStatus>, IEcnLogStatusRepository
    {
        private ApplicationDbContext _db;
        public EcnLogStatusRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EcnLogStatus obj)
        {
            _db.EcnLogStatuses.Update(obj);
        }
    }
}
