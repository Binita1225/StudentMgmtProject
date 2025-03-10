using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentMgmtProject.Model;
using StudentMgmtProject.Services.Report.ViewModels;

namespace StudentMgmtProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Programms> Programs { get; set; }

        public virtual List<StudentInfoVM> SelectAllStudents()
        {
            var data = this.Database.SqlQueryRaw<StudentInfoVM>("EXEC SelectAllStudents").ToList();
            return data;
        }

    }

}
