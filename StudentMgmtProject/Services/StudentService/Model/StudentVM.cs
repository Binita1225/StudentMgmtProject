using StudentMgmtProject.Model;
using System.ComponentModel.DataAnnotations;

namespace StudentMgmtProject.Services.StudentService.Model
{
    public class StudentVM
    {
        public int StudentId { get; set; }

        [Required, StringLength(50)]
        public string RollNo { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(15)]
        public string PhoneNumber { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required, StringLength(100)]
        public string Address { get; set; }

        [Required, StringLength(50)]
        public string FatherName { get; set; }

        [Required, StringLength(50)]
        public string MotherName { get; set; }

        public int ProgramId { get; set; }
        public string? ProgramName { get; set; }
    }
}