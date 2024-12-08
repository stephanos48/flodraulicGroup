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
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private ApplicationDbContext _db;
        public SupplierRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Supplier obj)
        {
            var objFromDb = _db.Suppliers.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.SupplierName = obj.SupplierName;
                objFromDb.SupplierNo = obj.SupplierNo;
                objFromDb.SupplierType = obj.SupplierType;
                objFromDb.City = obj.City;
                objFromDb.State = obj.State;
                objFromDb.Country = obj.Country;
                objFromDb.Phone = obj.Phone;
                objFromDb.Website = obj.Website;
                objFromDb.ImageUrl = obj.ImageUrl;
                objFromDb.Notes = obj.Notes;
            }
        }
    }
}
