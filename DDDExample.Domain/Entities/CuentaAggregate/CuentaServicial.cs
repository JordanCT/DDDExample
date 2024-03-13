using DDDExample.Domain.Exceptions;

namespace DDDExample.Domain.Entities.CuentaAggregate
{
    public class CuentaServicial : Cuenta
    {
        public CuentaServicial(int clienteId, decimal monto, string dni, int contador)
            : base(clienteId, monto, dni, contador, TipoCuenta.Servicial.Id)
        {
        }

        private CuentaServicial() { }

        protected override void Aperturar(decimal monto)
        {
            var montoMinimo = 300m;
            var comision = 0.10m;
            if (monto < montoMinimo)
                throw new MontoAperturaException(montoMinimo);
            Abonar(monto);
            Cargar(comision);
        }
    }
}
