using flodraulicproject.DataAccess.Data;
using flodraulicproject.DataAccess.Repository.IRepository;
using flodraulicproject.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.DataAccess.Repository
{
    public class MfgLocationRepository : Repository<MfgLocation>, IMfgLocationRepository
    {
        private ApplicationDbContext _db;
        public MfgLocationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(MfgLocation obj)
        {
            var objFromDb = _db.MfgLocations.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.MfgLocationName = obj.MfgLocationName;
                objFromDb.Notes = obj.Notes;
            }
        }
    }
}
