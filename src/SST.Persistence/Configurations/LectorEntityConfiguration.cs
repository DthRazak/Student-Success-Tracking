using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SST.Domain.Entities;

namespace SST.Persistence.Configurations
{
    class LectorEntityConfiguration : IEntityTypeConfiguration<Lector>
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
                .IsRequired();

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.Lector);

            builder
                .HasMany(x => x.Subjects)
                .WithOne(x => x.Lector);
        }
    }
}
