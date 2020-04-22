using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SST.Application.Common.Interfaces;
using SST.Domain.Entities;
using SST.Persistence.Configurations;
using SST.Persistence.Extensions;

namespace SST.Persistence
{
    public class SSTDbContext : DbContext, ISSTDbContext
    {
        public SSTDbContext(DbContextOptions<SSTDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Lector> Lectors { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<GroupSubject> GroupSubjects { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<SecondaryGroup> SecondaryGroups { get; set; }

        public DbSet<JournalColumn> JournalColumns { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GradeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GroupEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GroupSubjectEntityConfiguration());
            modelBuilder.ApplyConfiguration(new JournalColumnEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LectorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RequestEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SecondaryGroupEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StudentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());

            modelBuilder.Seed();
        }
    }
}
