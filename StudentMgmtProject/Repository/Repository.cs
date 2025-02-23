using Microsoft.EntityFrameworkCore;
using StudentMgmtProject.Data;
using System.Linq.Expressions;
using System.Linq;

namespace StudentMgmtProject.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public T Add(T model)
        {
            _dbSet.Add(model);
            _context.SaveChanges();
            return model;
        }

        public int Delete(int id)
        {
          var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                return _context.SaveChanges();
            }
            return 0;
        }

        public T Find(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> List()
        {
            return _dbSet.AsQueryable();
        }

        public int Remove(T model)
        {
            _dbSet.Remove(model);
            return _context.SaveChanges();
        }

        public T Update(T model)
        {
           _dbSet.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}