using StudentMgmtProject.Model;

namespace StudentMgmtProject.Repository.IRepository
{
    public interface IProgramRepository : IRepository<Programms>
    {
        IEnumerable<Programms> GetAll();
        void Update(Programms program);
    }
}
