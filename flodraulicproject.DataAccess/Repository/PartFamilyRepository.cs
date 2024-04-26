using flodraulicproject.DataAccess.Data;
using flodraulicproject.Models;
using flodraulicproject.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.DataAccess.Repository
{
    public class PartFamilyRepository : Repository<PartFamily>, IPartFamilyRepository
    {

        private ApplicationDbContext _db;
        public PartFamilyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PartFamily obj)
        {
            var objFromDb = _db.PartFamilies.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.FamilyName = obj.FamilyName;
                objFromDb.DisplayOrder = obj.DisplayOrder;

            }
        }

    }
}
