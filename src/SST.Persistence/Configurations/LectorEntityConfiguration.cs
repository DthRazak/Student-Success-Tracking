using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SST.Domain.Entities;

namespace SST.Persistence.Configurations
{
    public class LectorEntityConfiguration : IEntityTypeConfiguration<Lector>
    {
        public void Configure(EntityTypeBuilder<Lector> builder)
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
                .Property(x => x.AcademicStatus)
                .IsRequired();

            builder
                .Property(x => x.UserRef)
                .IsRequired(false);

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.Lector)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Subjects)
                .WithOne(x => x.Lector);
        }
    }
}
