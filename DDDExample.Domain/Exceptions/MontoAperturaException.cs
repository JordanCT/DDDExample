namespace DDDExample.Domain.Exceptions
{
    public class MontoAperturaException : Exception
    {
        public MontoAperturaException(decimal monto)
            : base($"El monto mínimo de apertura para este tipo de cuenta es: {monto}")
        { }
    }
}
