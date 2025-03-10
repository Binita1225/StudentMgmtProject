using System.ComponentModel.DataAnnotations;

namespace StudentMgmtProject.Model
{
    public enum ProgramType
    {
        Semester,
        Yearly
    }

    public class Programms
    {
        [Key]
        public int ProgramId { get; set; }

        [Required, StringLength(100)]
        public string ProgramName { get; set; }

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; } // Foreign key

        public int DurationInYears { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;

        public ProgramType ProgramType { get; set; }
    }
}

