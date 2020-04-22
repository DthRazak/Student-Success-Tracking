using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SST.Domain.Entities;

namespace SST.Persistence.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Email);

            builder
                .Property(x => x.PasswordHash)
                .HasColumnType("varchar(256)")
                .IsRequired();

            builder
                .Property(x => x.IsAdmin)
                .IsRequired();

            builder
                .HasOne(x => x.Request)
                .WithOne(x => x.User)
                .HasForeignKey<Request>(x => x.UserRef);

            builder
                .HasOne(x => x.Student)
                .WithOne(x => x.User)
                .HasForeignKey<Student>(x => x.UserRef)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(x => x.Lector)
                .WithOne(x => x.User)
                .HasForeignKey<Lector>(x => x.UserRef)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
