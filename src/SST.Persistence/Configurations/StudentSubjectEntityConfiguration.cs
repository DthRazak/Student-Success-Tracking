using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SST.Domain.Entities;

namespace SST.Persistence.Configurations
{
    class StudentSubjectEntityConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.SubjectRef)
                .IsRequired();

            builder
                .Property(x => x.StudentRef)
                .IsRequired();

            builder
                .HasOne(x => x.Subject)
                .WithMany(x => x.StudentSubjects)
                .HasForeignKey(x => x.SubjectRef)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Student)
                .WithMany(x => x.StudentSubjects)
                .HasForeignKey(x => x.StudentRef)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Grades)
                .WithOne(x => x.StudentSubject);
        }
    }
}
