using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using flodraulicproject.DataAccess.Data;
using flodraulicproject.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace flodraulicproject.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {

            _db = db;
            this.dbSet = _db.Set<T>();
            //_db.Categories = dbSet
            _db.Products.Include(u => u.Category).Include(u => u.CategoryId);
            _db.Products.Include(u => u.PartFamily).Include(u => u.PartFamilyId);
            _db.Inventories.Include(u => u.Product).Include(u => u.ProductId);
            _db.Inventories.Include(u => u.FloLocation).Include(u => u.FloLocationId);
            _db.ShoppingCarts.Include(u => u.FloLocation).Include(u => u.FloLocationId);
            _db.Tickets.Include(u => u.TicketStatus).Include(u => u.TicketStatusId);
            _db.TimeTrackers.Include(u => u.FloLocation).Include(u => u.FloLocationId);
            _db.TimeTrackers.Include(u => u.LaborCode).Include(u => u.LaborCodeId);
            _db.EngineeringLogs.Include(u => u.Estimator).Include(u => u.EstimatorId);
            _db.EngineeringLogs.Include(u => u.Engineer).Include(u => u.EngineerId);
            _db.EngineeringLogs.Include(u => u.MfgLocation).Include(u => u.MfgLocationId);
            _db.EngineeringLogs.Include(u => u.SalesLocation).Include(u => u.SalesLocationId);
            _db.EngineeringLogs.Include(u => u.LogStatus).Include(u => u.LogStatusId);
            _db.EngLogComments.Include(u => u.EngineeringLog).Include(u=>u.EngineeringLogId);
            //_db.ECNLogComments.Include(u => u.ECNLog).Include(u => u.ECNLogId);
            _db.EcnLogs.Include(u => u.EcnLogStatus).Include(u=>u.EcnLogStatusId);
            //_db.EcnLogs.Include(y => y.EngineeringLog).Include(y => y.EngineeringLogId);

        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;
            }
            else
            {
                query = dbSet.AsNoTracking();

            }

            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();

        }

        //Category,CoverType
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
