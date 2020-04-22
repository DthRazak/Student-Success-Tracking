using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SST.Domain.Entities;

namespace SST.Persistence.Configurations
{
    public class GroupEntityConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.Faculty)
                .IsRequired();

            builder
                .Property(x => x.Year)
                .IsRequired();

            builder
                .Property(x => x.IsMain)
                .IsRequired();

            builder
                .HasMany(x => x.Students)
                .WithOne(x => x.Group)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasMany(x => x.SecondaryGroups)
                .WithOne(x => x.Group);

            builder
                .HasMany(x => x.GroupSubjects)
                .WithOne(x => x.Group);
        }
    }
}
