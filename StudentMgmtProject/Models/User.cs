using System.ComponentModel.DataAnnotations;

namespace StudentMgmtProject.Model
{
    public enum UserRole
    {
        Admin,
        Student
    }
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, StringLength(50)]
        public string FullName { get; set; }
        [Required, StringLength(50)]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string PasswordHash { get; set; } // Store hashed passwords

        public UserRole Role { get; set; }
    }
    }

