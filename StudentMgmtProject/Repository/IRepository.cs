using System.Linq.Expressions;

namespace StudentMgmtProject.Repository
{
    public interface IRepository<T> where T : class
    {

        public IQueryable<T> List();
        public T Add(T model);
        public T Update(T model);
        public int Delete(int id);
        public int Remove(T model);
        public T Find(int id);
    }
}