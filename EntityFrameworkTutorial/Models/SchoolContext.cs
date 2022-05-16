using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTutorial.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=SchoolDB.db");
        }

        public DbSet<Student> Students => this.Set<Student>();
        public DbSet<Grade> Grades => this.Set<Grade>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<Student>().Property(s => s.Grade).IsRequired(false);
            builder.Entity<Student>().HasOne<Grade>(s => s.Grade).WithOne();
            builder.Entity<Grade>().HasOne<Student>(g => g.Prefect).WithMany();
        }
    }
}
