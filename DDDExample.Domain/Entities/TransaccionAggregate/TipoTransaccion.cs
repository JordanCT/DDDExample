namespace BCP.DemoCuentas.Domain.Entities.TransaccionAggregate
{
    public class TipoTransaccion
    {
        public static TipoTransaccion Deposito = new TipoTransaccion(1, nameof(Deposito).ToLowerInvariant());
        public static TipoTransaccion Retiro = new TipoTransaccion(2, nameof(Retiro).ToLowerInvariant());
        public static TipoTransaccion Transferencia = new TipoTransaccion(3, nameof(Transferencia).ToLowerInvariant());        
        public int Id { get; private set; }
        public string Descripcion { get; private set; }
        public TipoTransaccion(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;  
        }
    }
}
