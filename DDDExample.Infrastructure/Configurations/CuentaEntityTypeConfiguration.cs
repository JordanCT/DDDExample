using DDDExample.Domain.Entities.CuentaAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExample.Infrastructure.Configurations
{
    public class CuentaEntityTypeConfiguration : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.ToTable("Cuentas")
                .HasDiscriminator<string>("CuentaType")
                .HasValue<CuentaServicial>("CuentaServicial")
                .HasValue<CuentaFeliz>("CuentaFeliz");

            builder.HasKey(x => x.Id);

            builder.Property<int>("Id")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CuentaID");

            builder.Property<int>("ClienteId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ClienteID")
                .IsRequired();

            builder.OwnsOne(p => p.Numero)
                .Property<string>("Valor")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("NumeroCuenta")
                .IsRequired();

            builder.Property<decimal>("SaldoDisponible")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasPrecision(16,4)
                .IsRequired();

            builder.Property<decimal>("SaldoContable")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasPrecision(16, 4)
                .IsRequired();

            builder.HasOne(o => o.TipoCuenta)
            .WithMany()
            .HasForeignKey("TipoCuentaId");
        }
    }
}
