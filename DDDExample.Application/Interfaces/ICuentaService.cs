using DDDExample.Application.Dtos;

namespace DDDExample.Application.Interfaces
{
    public interface ICuentaService
    {
        Task<RegistrarCuentaResponseDto> CrearCuentaAsync(RegistrarCuentaRequestDto registrarCuentaRequestDto);
    }
}
