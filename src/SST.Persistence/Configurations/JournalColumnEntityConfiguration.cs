using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SST.Domain.Entities;

namespace SST.Persistence.Configurations
{
    public class JournalColumnEntityConfiguration : IEntityTypeConfiguration<JournalColumn>
    {
        public void Configure(EntityTypeBuilder<JournalColumn> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Date)
                .IsRequired();

            builder
                .Property(x => x.Note)
                .IsRequired(false);

            builder
                .Property(x => x.GroupSubjectRef)
                .IsRequired();

            builder
                .HasOne(x => x.GroupSubject)
                .WithMany(x => x.Journal)
                .HasForeignKey(x => x.GroupSubjectRef);

            builder
                .HasMany(x => x.Grades)
                .WithOne(x => x.JournalColumn);
        }
    }
}
