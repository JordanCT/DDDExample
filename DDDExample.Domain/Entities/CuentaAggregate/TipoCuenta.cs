using DDDExample.Domain.Exceptions;

namespace DDDExample.Domain.Entities.CuentaAggregate
{
    public class TipoCuenta
    {
        public static TipoCuenta Feliz = new TipoCuenta(1, nameof(Feliz));
        public static TipoCuenta Servicial = new TipoCuenta(2, nameof(Servicial));
        public int Id { get; private set; }
        public string Descripcion { get; private set; }

        public static IEnumerable<TipoCuenta> Listado() =>
            new[] { Feliz, Servicial };

        public TipoCuenta(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }

        public static TipoCuenta From(int id)
        {
            var tipoCuenta = Listado().SingleOrDefault(x => x.Id == id);

            if (tipoCuenta == null)
                throw new ValorNoSoportadoExcepcion(nameof(TipoCuenta), Listado().Select(x => x.Descripcion));

            return tipoCuenta;
        }
    }
}
