using DDDExample.Application.Dtos;

namespace DDDExample.Application.Interfaces
{
    public interface IClienteService
    {
        Task<RegistrarClienteResponseDto> AgregaClienteAsync(RegistrarClienteRequestDto registrarClienteDto);
    }
}
