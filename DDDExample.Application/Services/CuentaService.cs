using DDDExample.Application.Dtos;
using DDDExample.Application.Exceptions;
using DDDExample.Application.Extensions;
using DDDExample.Application.Interfaces;
using DDDExample.Domain.Entities;
using DDDExample.Domain.Interfaces;

namespace DDDExample.Application.Services
{
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IClienteRepository _clienteRepository;

        public CuentaService(ICuentaRepository cuentaRepository, IClienteRepository clienteRepository)
        {
            _cuentaRepository = cuentaRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<RegistrarCuentaResponseDto> CrearCuentaAsync(RegistrarCuentaRequestDto registrarCuentaRequestDto)
        {
            var cliente = await _clienteRepository.BuscarPorIdAsync(registrarCuentaRequestDto.ClienteId);
            if (cliente == null)
            {
                throw new NotFoundException(nameof(Cliente), registrarCuentaRequestDto.ClienteId);
            }
            var cuentaDto = cliente.MapToNewCuentaDto(registrarCuentaRequestDto);
            var cuenta = _cuentaRepository.Agregar(cuentaDto.MapToCuenta());
            await _cuentaRepository.UnitOfWork.GuardarCambiosAsync();
            return cuenta.MapToRegistrarCuentaResponseDto();
        }
    }
}
