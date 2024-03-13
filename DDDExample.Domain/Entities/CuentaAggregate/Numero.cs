using DDDExample.Domain.Bases;

namespace DDDExample.Domain.Entities.CuentaAggregate
{
    public class Numero : ValueObject
    {
        public string Valor { get; private set; }
        public Numero(int tipoCuentaId, string dni, int contador)
        {
            Valor = GenerarNumeroCuenta(tipoCuentaId, dni, contador);
        }

        private Numero() { }

        private string GenerarNumeroCuenta(int tipoCuentaId, string dni, int contador)
        {
            var numero = $"{tipoCuentaId:00}{dni.PadLeft(10, '0')}{contador:00}";
            return numero;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Valor;
        }
    }
}
