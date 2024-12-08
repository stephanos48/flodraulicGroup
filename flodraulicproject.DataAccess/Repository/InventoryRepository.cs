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
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        private ApplicationDbContext _db;
        public InventoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Inventory obj)
        {
            var objFromDb = _db.Inventories.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.ProductId = objFromDb.ProductId;
                objFromDb.FloLocationId = objFromDb.FloLocationId;
                objFromDb.StartQoh = obj.StartQoh;
            }

        }
    }
}
