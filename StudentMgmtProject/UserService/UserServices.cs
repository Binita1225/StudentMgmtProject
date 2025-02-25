using Microsoft.IdentityModel.Tokens;
using StudentMgmtProject.Model;
using StudentMgmtProject.Repository;
using StudentMgmtProject.UserService.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentMgmtProject.UserService
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;

        public UserServices(IRepository<User> userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public string Register(SignupVM model)
        {
           var existingUser = _userRepository.List().FirstOrDefault(u => u.UserName == model.UserName);
            if (existingUser != null)
            {
                return "User already exists";
            }
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);

            var user = new User
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = hashedPassword,
                Role = UserRole.Student
            };
            _userRepository.Add(user);
            return "User registered successfully";
        }

        public string Login(LoginVM model)
        {
            var user = _userRepository.List().FirstOrDefault(u => u.UserName == model.UserName);
            if (user == null)
            {
                return "User not found";
            }
            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            {
                return "Invalid password";
            }
            return GenerateJwtToken(user);
        }

     

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.List().ToList();
        }

        public User GetUserById(int id)
        {
            return _userRepository.Find(id);
        }

        public string UpdateUser(int id, SignupVM model)
        {
            var user = _userRepository.Find(id);
            if (user == null)
            {
                return "User not found";
            }
            user.FullName = model.FullName;
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);
            user.Role = model.Role;

            _userRepository.Update(user);
            return "User updated successfully";
        }

        public string DeleteUser(int id)
        {
            var user = _userRepository.Find(id);
            if (user == null)
            {
                return "User not found";
            }
            _userRepository.Remove(user);
            return "User deleted successfully";
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Retrieve the key from the configuration
            var jwtKey = _configuration["Jwt:SecretKey"]; // Change this line

            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new ArgumentNullException("Jwt:SecretKey", "JWT Secret Key is missing in appsettings.json"); // Change this line too
            }

            var key = Encoding.UTF8.GetBytes(jwtKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim("UserId", user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
