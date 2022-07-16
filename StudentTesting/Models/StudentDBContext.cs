using Microsoft.EntityFrameworkCore;

namespace StudentTesting.Models
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext() { }

        public StudentDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Studenttbl> studenttbls { get; set; }

        public DbSet<Teachertbl> teachertbls { get; set; }

        public DbSet<Marks> marks { get; set; }
        
    }
}