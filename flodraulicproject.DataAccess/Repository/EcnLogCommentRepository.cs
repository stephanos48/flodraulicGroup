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
    public class EcnLogCommentRepository : Repository<EcnLogComment>, IEcnLogCommentRepository
    {
        private ApplicationDbContext _db;
        public EcnLogCommentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EcnLogComment obj)
        {
            _db.EcnLogComments.Update(obj);
        }
    }
}
