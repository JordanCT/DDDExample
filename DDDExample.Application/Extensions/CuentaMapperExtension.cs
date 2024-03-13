using DDDExample.Application.Dtos;
using DDDExample.Application.Dtos.Internal;
using DDDExample.Application.Exceptions;
using DDDExample.Domain.Entities;
using DDDExample.Domain.Entities.CuentaAggregate;

namespace DDDExample.Application.Extensions
{
    public static class CuentaMapperExtension
    {
        public static Cuenta MapToCuenta(this NewCuentaDto dto)
        {
            if (dto.TipoCuenta == TipoCuenta.Feliz.Id)
                return new CuentaFeliz(dto.ClienteId, dto.Monto, dto.Dni, dto.Contador);
            else if (dto.TipoCuenta == TipoCuenta.Servicial.Id)
                return new CuentaServicial(dto.ClienteId, dto.Monto, dto.Dni, dto.Contador);
            else
                throw new NotFoundException(nameof(TipoCuenta), dto.TipoCuenta);
        }

        public static RegistrarCuentaResponseDto MapToRegistrarCuentaResponseDto(this Cuenta entity) =>
                new RegistrarCuentaResponseDto
                {
                    CuentaId = entity.Id,
                    NumeroCuenta = entity.Numero.Valor,
                    TipoCuenta = TipoCuenta.From(entity.TipoCuentaId).Descripcion,
                    SaldoContable = entity.SaldoContable,
                    SaldoDisponible = entity.SaldoDisponible,
                };

        public static NewCuentaDto MapToNewCuentaDto(this Cliente entity, RegistrarCuentaRequestDto baseDto) =>
            new NewCuentaDto
            {
                ClienteId = entity.Id,
                Dni = entity.Dni,
                TipoCuenta = baseDto.TipoCuenta,
                Contador = entity.ObtenerTotalCuentas(),
                Monto = baseDto.Monto
            };
    }
}
