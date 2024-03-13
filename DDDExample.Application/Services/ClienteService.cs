using DDDExample.Application.Dtos;
using DDDExample.Application.Exceptions;
using DDDExample.Application.Extensions;
using DDDExample.Application.Interfaces;
using DDDExample.Domain.Entities;
using DDDExample.Domain.Interfaces;

namespace DDDExample.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<RegistrarClienteResponseDto> AgregaClienteAsync(RegistrarClienteRequestDto registrarClienteDto)
        {
            var cliente = await _clienteRepository.BuscarPorDniAsync(registrarClienteDto.Dni);
            if (cliente is not null)
                throw new AlreadyExistException(nameof(Cliente), cliente.Dni);

            cliente = _clienteRepository.Agregar(registrarClienteDto.MapToCliente());
            await _clienteRepository.UnitOfWork.GuardarCambiosAsync();
            return cliente.MapToRegistrarClienteResponseDto();
        }
    }
}
