using flodraulicproject.DataAccess.Data;
using flodraulicproject.DataAccess.Repository.IRepository;
using flodraulicproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.DataAccess.Repository
{
    public class FloContactRepository : Repository<FloContact>, IFloContactRepository
    {

        private ApplicationDbContext _db;
        public FloContactRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(FloContact obj)
        {
            var objFromDb = _db.FloContacts.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.FloLocationId = obj.FloLocationId;
                objFromDb.PhoneNumber = obj.PhoneNumber;
                objFromDb.Email = obj.Email;
                objFromDb.Notes = obj.Notes;
            }
        }

    }
}
