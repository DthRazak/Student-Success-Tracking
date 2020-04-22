using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SST.Domain.Entities;

namespace SST.Persistence.Configurations
{
    public class SecondaryGroupEntityConfiguration : IEntityTypeConfiguration<SecondaryGroup>
    {
        public void Configure(EntityTypeBuilder<SecondaryGroup> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.StudentRef)
                .IsRequired();

            builder
                .Property(x => x.GroupRef)
                .IsRequired();

            builder
                .HasOne(x => x.Student)
                .WithMany(x => x.SecondaryGroups)
                .HasForeignKey(x => x.StudentRef);

            builder
                .HasOne(x => x.Group)
                .WithMany(x => x.SecondaryGroups)
                .HasForeignKey(x => x.GroupRef);
        }
    }
}
