using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Name)
        .HasColumnType("varchar(50)")
        .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.Password)
         .HasColumnType("text")
         .IsRequired();

    }
}
