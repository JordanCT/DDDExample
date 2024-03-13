﻿// <auto-generated />
using DDDExample.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DDDExample.Infrastructure.Migrations
{
    [DbContext(typeof(DemoCuentasContext))]
    partial class DemoCuentasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DDDExample.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ClienteID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("DDDExample.Domain.Entities.CuentaAggregate.Cuenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CuentaID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("ClienteID");

                    b.Property<string>("CuentaType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SaldoContable")
                        .HasPrecision(16, 4)
                        .HasColumnType("decimal(16,4)");

                    b.Property<decimal>("SaldoDisponible")
                        .HasPrecision(16, 4)
                        .HasColumnType("decimal(16,4)");

                    b.Property<int>("TipoCuentaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoCuentaId");

                    b.ToTable("Cuentas", (string)null);

                    b.HasDiscriminator<string>("CuentaType").HasValue("Cuenta");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DDDExample.Domain.Entities.CuentaAggregate.TipoCuenta", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("TipoCuentaID");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("TiposCuenta", (string)null);
                });

            modelBuilder.Entity("DDDExample.Domain.Entities.CuentaAggregate.CuentaServicial", b =>
                {
                    b.HasBaseType("DDDExample.Domain.Entities.CuentaAggregate.Cuenta");

                    b.HasDiscriminator().HasValue("CuentaServicial");
                });

            modelBuilder.Entity("DDDExample.Domain.Entities.CuentaAggregate.CuentaFeliz", b =>
                {
                    b.HasBaseType("DDDExample.Domain.Entities.CuentaAggregate.Cuenta");

                    b.HasDiscriminator().HasValue("CuentaFeliz");
                });

            modelBuilder.Entity("DDDExample.Domain.Entities.CuentaAggregate.Cuenta", b =>
                {
                    b.HasOne("DDDExample.Domain.Entities.Cliente", null)
                        .WithMany("Cuentas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDDExample.Domain.Entities.CuentaAggregate.TipoCuenta", "TipoCuenta")
                        .WithMany()
                        .HasForeignKey("TipoCuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("DDDExample.Domain.Entities.CuentaAggregate.Numero", "Numero", b1 =>
                        {
                            b1.Property<int>("CuentaId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("NumeroCuenta");

                            b1.HasKey("CuentaId");

                            b1.ToTable("Cuentas");

                            b1.WithOwner()
                                .HasForeignKey("CuentaId");
                        });

                    b.Navigation("Numero")
                        .IsRequired();

                    b.Navigation("TipoCuenta");
                });

            modelBuilder.Entity("DDDExample.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Cuentas");
                });
#pragma warning restore 612, 618
        }
    }
}
