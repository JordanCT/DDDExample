using DDDExample.Domain.Exceptions;

namespace DDDExample.Domain.Entities.CuentaAggregate
{
    public class CuentaFeliz : Cuenta
    {
        public CuentaFeliz(int clienteId, decimal monto, string dni, int contador)
            : base(clienteId, monto, dni, contador, TipoCuenta.Feliz.Id)
        {
        }

        private CuentaFeliz() { }

        protected override void Aperturar(decimal monto)
        {
            var montoMinimo = 100m;
            if (monto < montoMinimo)
                throw new MontoAperturaException(montoMinimo);
            Abonar(monto);
        }
    }
}
