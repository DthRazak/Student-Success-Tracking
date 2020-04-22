using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SST.Domain.Entities;

namespace SST.Application.Common.Interfaces
{
    public interface ISSTDbContext
    {
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

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
