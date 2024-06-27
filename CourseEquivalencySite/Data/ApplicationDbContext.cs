using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CourseEquivalencySite.Models;

namespace CourseEquivalencySite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Course> course { get; set; }
        public DbSet<Institution> institutions { get; set; }
        public DbSet<Major> majors { get; set; }
        
    }
}
