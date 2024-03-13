namespace DDDExample.Application.Dtos.Internal
{
    public class NewCuentaDto
    {
        public int ClienteId { get; set; }
        public int TipoCuenta { get; set; }
        public decimal Monto { get; set; }
        public string Dni { get; set; }
        public int Contador { get; set; }
    }
}
