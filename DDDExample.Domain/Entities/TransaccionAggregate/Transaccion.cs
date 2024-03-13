namespace BCP.DemoCuentas.Domain.Entities.TransaccionAggregate
{
    public class Transaccion
    {
        public int Id { get; private set; }
        public int CuentaId { get; private set; }
        public decimal Monto { get; private set; }
        public decimal Comision { get; private set; }
        public decimal Total { get; private set; }
        public DateTime Fecha { get; private set; }
        public TipoTransaccion TipoTransaccion { get; private set; }
        private int _tipoTransaccionId;
        public Transaccion(int cuentaId, decimal monto, decimal comision, int tipoTransaccionId)
        {
            CuentaId = cuentaId;
            Monto = monto;
            Comision = comision;
            Fecha = DateTime.Now;
            _tipoTransaccionId = tipoTransaccionId;
            ActualizarTotal();
        }

        private void ActualizarTotal() 
        {
            Total = Monto - Comision;
        }
    }
}
