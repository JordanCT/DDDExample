using DDDExample.Application.Dtos;
using DDDExample.Domain.Entities;

namespace DDDExample.Application.Extensions
{
    public static class ClienteMapperExtension
    {
        public static Cliente MapToCliente(this RegistrarClienteRequestDto dto) =>
            new Cliente(dto.Dni, dto.ApellidoPaterno, dto.ApellidoMaterno, dto.Nombres);

        public static RegistrarClienteResponseDto MapToRegistrarClienteResponseDto(this Cliente entity) => 
            new RegistrarClienteResponseDto 
            { 
                ClienteId = entity.Id, 
                NombreCompleto = $"{entity.Nombres} {entity.ApellidoPaterno} {entity.ApellidoMaterno}" 
            };
    }
}
