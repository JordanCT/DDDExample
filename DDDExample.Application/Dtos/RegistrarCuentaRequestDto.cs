namespace DDDExample.Application.Dtos
{
    public class RegistrarCuentaRequestDto
    {
        public int ClienteId { get; set; }
        public int TipoCuenta { get; set; }
        public decimal Monto { get; set; }
    }
}
