using DDDExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDExample.Infrastructure.Configurations
{
    public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(x => x.Id);

            builder.Property<int>("Id")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ClienteID");

            builder.Property<string>("Dni")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired();

            builder.Property<string>("ApellidoPaterno")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired();

            builder.Property<string>("ApellidoMaterno")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired();

            builder.Property<string>("Nombres")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .IsRequired();

            builder.HasMany(x => x.Cuentas)
            .WithOne()
            .HasForeignKey("ClienteId");
        }
    }
}
