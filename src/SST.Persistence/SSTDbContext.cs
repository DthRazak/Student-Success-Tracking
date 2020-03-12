using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;
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
            // TODO : apply configurations
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
