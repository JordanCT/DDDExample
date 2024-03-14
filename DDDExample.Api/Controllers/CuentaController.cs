using DDDExample.Application.Dtos;
using DDDExample.Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DDDExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;
        private readonly IValidator<RegistrarCuentaRequestDto> _validator;

        public CuentaController(ICuentaService cuentaService, IValidator<RegistrarCuentaRequestDto> validator)
        {
            _cuentaService = cuentaService;
            _validator = validator;
        }

        [HttpPost("crearCuenta")]
        public async Task<IActionResult> CrearCuenta([FromBody] RegistrarCuentaRequestDto request)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                throw new Application.Exceptions.ValidationException(validationResult.Errors);

            var response = await _cuentaService.CrearCuentaAsync(request);
            return Ok(response);
        }
    }
}
