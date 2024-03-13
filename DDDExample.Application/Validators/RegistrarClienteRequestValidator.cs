using DDDExample.Application.Dtos;
using FluentValidation;

namespace DDDExample.Application.Validators
{
    public class RegistrarClienteRequestValidator : AbstractValidator<RegistrarClienteRequestDto>
    {
        public RegistrarClienteRequestValidator()
        {
            RuleFor(x => x.Dni)
                .Matches("^[0-9]{8}$").WithMessage("El Dni debe tener 8 Digitos");
            RuleFor(x => x.ApellidoPaterno)
                .NotEmpty().WithMessage("El Apellido Paterno no puede estar vacío");
            RuleFor(x => x.ApellidoMaterno)
                .NotEmpty().WithMessage("El Apellido Materno no puede estar vacío");
            RuleFor(x => x.Nombres)
                .NotEmpty().WithMessage("El Nombre no puede estar vacío");
        }
    }
}
