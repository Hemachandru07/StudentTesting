using Microsoft.EntityFrameworkCore;

namespace StudentTesting.Models
{
    public class TestingDBContext : DbContext
    {
        public TestingDBContext() { }

        public TestingDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Studenttbl> studenttbls { get; set; }

        public DbSet<Teachertbl> teachertbls { get; set; }
    }
}