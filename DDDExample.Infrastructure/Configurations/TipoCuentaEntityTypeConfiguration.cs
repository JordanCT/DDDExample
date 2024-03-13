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
    public class TipoCuentaEntityTypeConfiguration : IEntityTypeConfiguration<TipoCuenta>
    {
        public void Configure(EntityTypeBuilder<TipoCuenta> builder)
        {
            builder.ToTable("TiposCuenta");
            
            builder.HasKey(o => o.Id);

            builder.Property<int>("Id")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .ValueGeneratedNever()
                .HasColumnName("TipoCuentaID")
                .IsRequired();

            builder.Property(o => o.Descripcion)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
