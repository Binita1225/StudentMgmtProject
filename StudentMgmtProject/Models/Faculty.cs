using System.ComponentModel.DataAnnotations;

namespace StudentMgmtProject.Model
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }

        [Required, StringLength(100)]
        public string FacultyName { get; set; }

        //public ICollection<Programms> Programs { get; set; }
    }
    }