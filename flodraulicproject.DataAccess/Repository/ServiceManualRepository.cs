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
    public class ServiceManualRepository : Repository<ServiceManual>, IServiceManualRepository
    {
        private ApplicationDbContext _db;
        public ServiceManualRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ServiceManual obj)
        {
            var objFromDb = _db.ServiceManuals.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.ManualName = obj.ManualName;
                objFromDb.ManualType = obj.ManualType;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
