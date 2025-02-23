using StudentMgmtProject.Data;
using StudentMgmtProject.Model;
using StudentMgmtProject.Repository.IRepository;

namespace StudentMgmtProject.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
       private ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }
        public void Update(User user)
        {
            _db.Update(user);
        }
    }
}
