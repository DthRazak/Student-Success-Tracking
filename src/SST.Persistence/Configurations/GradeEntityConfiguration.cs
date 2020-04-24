using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SST.Domain.Entities;

namespace SST.Persistence.Configurations
{
    public class GradeEntityConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Mark)
                .IsRequired();

            builder
                .Property(x => x.StudentRef)
                .IsRequired();

            builder
                .Property(x => x.JournalColumnRef)
                .IsRequired();

            builder
                .HasOne(x => x.Student)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.StudentRef);

            builder
                .HasOne(x => x.JournalColumn)
                .WithMany(x => x.Grades)
                .HasForeignKey(x => x.JournalColumnRef);
        }
    }
}
