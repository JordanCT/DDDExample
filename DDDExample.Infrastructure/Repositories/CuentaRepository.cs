using DDDExample.Domain.Bases;
using DDDExample.Domain.Entities.CuentaAggregate;
using DDDExample.Domain.Interfaces;
using DDDExample.Infrastructure.Context;

namespace DDDExample.Infrastructure.Repositories
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly DemoCuentasContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public CuentaRepository(DemoCuentasContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Cuenta Agregar(Cuenta cuenta)
        {
            return _context.Cuentas
                .Add(cuenta)
                .Entity;
        }
    }
}
