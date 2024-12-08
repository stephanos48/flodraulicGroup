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
    public class EngineeringLogImageRepository : Repository<EngineeringLogImage>, IEngineeringLogImageRepository
    {
        private ApplicationDbContext _db;
        public EngineeringLogImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EngineeringLogImage obj)
        {
            _db.EngineeringLogImages.Update(obj);
        }
    }
}
