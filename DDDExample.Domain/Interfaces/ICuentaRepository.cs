using DDDExample.Domain.Bases;
using DDDExample.Domain.Entities.CuentaAggregate;

namespace DDDExample.Domain.Interfaces
{
    public interface ICuentaRepository : IRepository<Cuenta>
    {
        Cuenta Agregar(Cuenta cuenta);
    }
}
