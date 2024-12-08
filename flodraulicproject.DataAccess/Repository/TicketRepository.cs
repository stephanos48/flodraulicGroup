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
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        private ApplicationDbContext _db;
        public TicketRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Ticket obj)
        {
            var objFromDb = _db.Tickets.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Issue = obj.Issue;
                objFromDb.ApplicationUserId = obj.ApplicationUserId;
                objFromDb.TicketStatusId = obj.TicketStatusId;
                objFromDb.Notes = obj.Notes;
            }
        }
    }
}
