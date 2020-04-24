using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SST.Domain.Entities;

namespace SST.Persistence.Configurations
{
    public class GroupSubjectEntityConfiguration : IEntityTypeConfiguration<GroupSubject>
    {
        public void Configure(EntityTypeBuilder<GroupSubject> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.GroupRef)
                .IsRequired();

            builder
                .Property(x => x.SubjectRef)
                .IsRequired();

            builder
                .HasOne(x => x.Group)
                .WithMany(x => x.GroupSubjects)
                .HasForeignKey(x => x.GroupRef);

            builder
                .HasOne(x => x.Subject)
                .WithMany(x => x.GroupSubjects)
                .HasForeignKey(x => x.SubjectRef);

            builder
                .HasMany(x => x.Journal)
                .WithOne(x => x.GroupSubject);
        }
    }
}
