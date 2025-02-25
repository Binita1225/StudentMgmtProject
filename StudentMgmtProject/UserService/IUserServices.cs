using StudentMgmtProject.Model;
using StudentMgmtProject.UserService.Model;

namespace StudentMgmtProject.UserService
{
    public interface IUserServices
    {
        string Register(SignupVM model);
        string Login(LoginVM model);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        string UpdateUser(int id, SignupVM model);
        string DeleteUser(int id);
    }
}
