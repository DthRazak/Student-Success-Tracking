using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SST.Domain.Entities;

namespace SST.Persistence.Configurations
{
    class GradeEntityConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Mark)
                .IsRequired();

            builder
                .Property(x => x.StudentSubjectRef)
                .IsRequired();

            builder
                .HasOne(x => x.StudentSubject)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.StudentSubjectRef);
        }
    }
}
