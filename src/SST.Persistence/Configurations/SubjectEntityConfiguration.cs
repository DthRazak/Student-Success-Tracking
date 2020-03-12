using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SST.Domain.Entities;

namespace SST.Persistence.Configurations
{
    class SubjectEntityConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.LectorRef)
                .IsRequired();

            builder
                .HasOne(x => x.Lector)
                .WithMany(x => x.Subjects)
                .HasForeignKey(x => x.LectorRef);

            builder
                .HasMany(x => x.StudentSubjects)
                .WithOne(x => x.Subject);
        }
    }
}
