using DDDExample.Application.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExample.Application.Validators
{
    public class RegistrarCuentaRequestValidator : AbstractValidator<RegistrarCuentaRequestDto>
    {
        public RegistrarCuentaRequestValidator()
        {
            RuleFor(x => x.ClienteId)
                .GreaterThan(0).WithMessage("El cliente es requerido");
            RuleFor(x => x.TipoCuenta)
                .GreaterThan(0).WithMessage("Debe indicar un tipo de cuenta");
            RuleFor(x => x.Monto)
                .GreaterThan(0).WithMessage("El monto de apertura debe ser mayor a 0");
        }
    }
}
