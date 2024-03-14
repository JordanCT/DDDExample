using DDDExample.Domain.Bases;
using DDDExample.Domain.Entities;
using DDDExample.Domain.Entities.CuentaAggregate;
using DDDExample.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DDDExample.Infrastructure.Context
{
    public class DemoCuentasContext : DbContext, IUnitOfWork
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<TipoCuenta> TiposCuenta { get; set; }
        public DemoCuentasContext(DbContextOptions<DemoCuentasContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CuentaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TipoCuentaEntityTypeConfiguration());
        }
        public async Task<int> GuardarCambiosAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
