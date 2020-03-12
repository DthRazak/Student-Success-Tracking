using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;
using SST.Persistence.Configurations;
using System.Threading;
using System.Threading.Tasks;

namespace SST.Persistence
{
    public class SSTDbContext : DbContext, ISSTDbContext
    {
        public SSTDbContext(DbContextOptions<SSTDbContext> options)
            :base(options)
        {}

        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Lector> Lectors { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<StudentSubject> StudentSubjects { get; set; }

        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GradeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LectorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RequestEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StudentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StudentSubjectEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
