using System.ComponentModel.DataAnnotations;

namespace StudentMgmtProject.Model
{
    public class Programms
    {
        [Key]
        public int ProgramId { get; set; }

        [Required, StringLength(100)]
        public string ProgramName { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; } // Foreign key
    }
}

