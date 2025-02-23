using StudentMgmtProject.Model;

namespace StudentMgmtProject.Repository.IRepository
{
    public interface IFacultyRepository : IRepository<Faculty>
    {
        IEnumerable<Faculty> GetAll();
        void Update(Faculty faculty);
    }
}
