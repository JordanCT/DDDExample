using DDDExample.Application.Dtos;
using DDDExample.Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DDDExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IValidator<RegistrarClienteRequestDto> _validator;

        public ClienteController(IClienteService clienteService, IValidator<RegistrarClienteRequestDto> validator)
        {
            _clienteService = clienteService;
            _validator = validator;
        }

        [HttpPost("crearCliente")]
        public async Task<IActionResult> CrearClienteAsync([FromBody] RegistrarClienteRequestDto request)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                throw new Application.Exceptions.ValidationException(validationResult.Errors);

            var response = await _clienteService.AgregaClienteAsync(request);
            return Ok(response);
        }
    }
}
