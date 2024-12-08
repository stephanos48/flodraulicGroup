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
    public class ShippedQtyRepository : Repository<ShippedQty>, IShippedQtyRepository
    {
        private ApplicationDbContext _db;
        public ShippedQtyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ShippedQty obj)
        {
            var objFromDb = _db.ShippedQtys.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.PartNumber = obj.PartNumber;
                objFromDb.ProductId = obj.ProductId;
                objFromDb.LocationName = obj.LocationName;
                objFromDb.FloLocationId = obj.FloLocationId;
                objFromDb.QtyShipped = obj.QtyShipped;
                objFromDb.OrderNoId = obj.OrderNoId;
                objFromDb.ShipDate = obj.ShipDate;
            }
        }
    }
}
