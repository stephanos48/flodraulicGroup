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
    public class SalesLocationRepository : Repository<SalesLocation>, ISalesLocationRepository
    {
        private ApplicationDbContext _db;
        public SalesLocationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SalesLocation obj)
        {
            var objFromDb = _db.SalesLocations.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.SalesLocationName = obj.SalesLocationName;
                objFromDb.Notes = obj.Notes;
            }
        }
    }
}
