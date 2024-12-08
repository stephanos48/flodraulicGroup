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
    public class FloLocationRepository : Repository<FloLocation>, IFloLocationRepository
    {
        private ApplicationDbContext _db;
        public FloLocationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(FloLocation obj)
        {
            var objFromDb = _db.FloLocations.FirstOrDefault(u => u.FloLocationId == obj.FloLocationId);
            if (objFromDb != null)
            {
                objFromDb.LocationName = objFromDb.LocationName;
                objFromDb.Address = obj.Address;
                objFromDb.City = obj.City;
                objFromDb.State = obj.State;
                objFromDb.ZipCode = obj.ZipCode;
                objFromDb.Country = obj.Country;
                objFromDb.Notes = obj.Notes;

            }
        }
    }
}
