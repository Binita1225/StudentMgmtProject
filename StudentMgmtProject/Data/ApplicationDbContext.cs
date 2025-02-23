using Microsoft.EntityFrameworkCore;
using StudentMgmtProject.Model;

namespace StudentMgmtProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Programms> Programs { get; set; }

    }

}
