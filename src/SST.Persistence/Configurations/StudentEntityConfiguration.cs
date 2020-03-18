using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SST.Domain.Entities;

namespace SST.Persistence.Configurations
{
    class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.FirstName)
                .IsRequired();

            builder
                .Property(x => x.LastName)
                .IsRequired();

            builder
                .Property(x => x.Group)
                .IsRequired();

            builder
                .Property(x => x.UserRef);

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.Student)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.StudentSubjects)
                .WithOne(x => x.Student);
        }
    }
}
