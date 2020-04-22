using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SST.Domain.Entities;

namespace SST.Persistence.Configurations
{
    public class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
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
                .Property(x => x.GroupRef)
                .IsRequired(false);

            builder
                .Property(x => x.UserRef)
                .IsRequired(false);

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.Student)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Group)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.GroupRef);

            builder
                .HasMany(x => x.Grades)
                .WithOne(x => x.Student);

            builder
                .HasMany(x => x.SecondaryGroups)
                .WithOne(x => x.Student);
        }
    }
}
