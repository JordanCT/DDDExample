using DDDExample.Domain.Bases;
using DDDExample.Domain.Entities;

namespace DDDExample.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente Agregar(Cliente cliente);
        Cliente Actualizar(Cliente cliente);
        Task<Cliente> BuscarPorIdAsync(int id);
        Task<Cliente> BuscarPorDniAsync(string dni);
    }
}
