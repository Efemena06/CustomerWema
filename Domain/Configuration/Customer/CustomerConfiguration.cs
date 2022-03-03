using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration.Customer;

public class CustomerConfiguration : IEntityTypeConfiguration<Domain.Entities.CustomerApp.Customer>
{

    public void Configure(EntityTypeBuilder<Entities.CustomerApp.Customer> builder)
    {
        builder.Property(p => p.PhoneNumber)
            .HasMaxLength(10);

        builder.Property(p => p.Email)
            .HasMaxLength(50);

        builder.Property(p => p.State)
            .HasMaxLength(50);

        builder.Property(p => p.Password)
            .HasMaxLength(100);

        builder.Property(p => p.LGA)
            .HasMaxLength(50);
    }
}
