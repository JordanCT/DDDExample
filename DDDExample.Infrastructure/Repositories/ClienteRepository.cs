using DDDExample.Domain.Bases;
using DDDExample.Domain.Entities;
using DDDExample.Domain.Interfaces;
using DDDExample.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DDDExample.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DemoCuentasContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ClienteRepository(DemoCuentasContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Cliente Agregar(Cliente cliente)
        {
            return _context.Clientes
                .Add(cliente)
                .Entity;
        }

        public Cliente Actualizar(Cliente cliente)
        {
            return _context.Clientes
                .Update(cliente)
                .Entity;
        }        

        public async Task<Cliente> BuscarPorIdAsync(int id)
        {
            var cliente = await _context.Clientes
                .Include(x => x.Cuentas)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            return cliente;
        }

        public async Task<Cliente> BuscarPorDniAsync(string dni)
        {
            var cliente = await _context.Clientes
                .Include(x => x.Cuentas)
                .Where(x => x.Dni == dni)
                .SingleOrDefaultAsync();

            return cliente;
        }
    }
}
