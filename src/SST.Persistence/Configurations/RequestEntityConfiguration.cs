using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SST.Domain.Entities;

namespace SST.Persistence.Configurations
{
    class RequestEntityConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.IsApproved)
                .IsRequired();

            builder
                .Property(x => x.CreationDate)
                .IsRequired();

            builder
                .Property(x => x.UserRef)
                .IsRequired();

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.Request);
        }
    }
}
