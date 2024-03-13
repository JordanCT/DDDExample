namespace DDDExample.Application.Dtos
{
    public class RegistrarCuentaResponseDto
    {
        public int CuentaId { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoDisponible { get; set; }
        public decimal SaldoContable { get; set; }
    }
}
