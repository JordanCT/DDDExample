using DDDExample.Domain.Bases;
using DDDExample.Domain.Entities.CuentaAggregate;

namespace DDDExample.Domain.Entities
{
    public class Cliente : IAggregateRoot
    {
        public int Id { get; private set; }
        public string Dni { get; private set; }
        public string ApellidoPaterno { get; private set; }
        public string ApellidoMaterno { get; private set; }
        public string Nombres { get; private set; }

        private readonly List<Cuenta> _cuentas;
        public IReadOnlyCollection<Cuenta> Cuentas => _cuentas;

        public Cliente(string dni, string apellidoPaterno, string apellidoMaterno, string nombres)
        {
            Dni = dni;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Nombres = nombres;
            _cuentas= new List<Cuenta>();
        }

        public int ObtenerTotalCuentas() 
        {
            return _cuentas.Count;
        }
    }
}
