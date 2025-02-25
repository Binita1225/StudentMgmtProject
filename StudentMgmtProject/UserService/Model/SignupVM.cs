using StudentMgmtProject.Model;

namespace StudentMgmtProject.UserService.Model
{
    public class SignupVM
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
    }
}
