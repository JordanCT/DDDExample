using DDDExample.Domain.Bases;

namespace DDDExample.Domain.Entities.CuentaAggregate
{
    public abstract class Cuenta : IAggregateRoot
    {
        public int Id { get; private set; }
        public int ClienteId { get; private set; }
        public decimal SaldoDisponible { get; private set; }
        public decimal SaldoContable { get; private set; }
        public Numero Numero { get; private set; }
        public TipoCuenta TipoCuenta { get; private set; }
        public int TipoCuentaId { get; private set; }

        protected Cuenta() { }
        public Cuenta(int clienteId, decimal monto, string dni,
            int contador, int tipoCuentaId)
        {
            ClienteId = clienteId;
            TipoCuentaId = tipoCuentaId;
            Numero = new Numero(TipoCuentaId, dni, contador);
            Aperturar(monto);
        }
        protected abstract void Aperturar(decimal monto);

        public void Abonar(decimal monto)
        {
            SaldoDisponible += monto;
            SaldoContable += monto;
        }
        public void Cargar(decimal monto)
        {
            SaldoDisponible -= monto;
            SaldoContable -= monto;
        }
    }
}