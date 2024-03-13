namespace DDDExample.Domain.Exceptions
{
    public class ValorNoSoportadoExcepcion : Exception
    {
        public ValorNoSoportadoExcepcion(string entidad, IEnumerable<string> valores)
            : base($"Valores posibles para {entidad}: {String.Join(",", valores)}")
        { }
    }
}
