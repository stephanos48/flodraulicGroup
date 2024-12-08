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
    public class SupplierContactRepository : Repository<SupplierContact>, ISupplierContactRepository
    {
        private ApplicationDbContext _db;
        public SupplierContactRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SupplierContact obj)
        {
            var objFromDb = _db.SupplierContacts.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.ContactName = obj.ContactName;
                objFromDb.OfficeLocation = obj.OfficeLocation;
                objFromDb.Cell = obj.Cell;
                objFromDb.Email = obj.Email;
                objFromDb.Notes = obj.Notes;
            }
        }
    }
}
