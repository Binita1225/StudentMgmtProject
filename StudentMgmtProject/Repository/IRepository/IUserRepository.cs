using StudentMgmtProject.Model;

namespace StudentMgmtProject.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAll();
        void Update(User user);
    }
}
