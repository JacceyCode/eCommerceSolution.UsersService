using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersService _usersService;
    private readonly IValidator<LoginRequest> _loginValidator;
    private readonly IValidator<RegisterRequest> _registerValidator;

    public AuthController(IUsersService usersServie, IValidator<LoginRequest> loginValidator, IValidator<RegisterRequest> registerValidator)
    {
        _usersService = usersServie;
        _loginValidator = loginValidator;
        _registerValidator = registerValidator;
    }

    [HttpPost("register")] // POST: api/auth/register
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        // Validate request using FluentValidation
        ValidationResult validationResult = await _registerValidator.ValidateAsync(registerRequest);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.PropertyName + ": " + e.ErrorMessage));
        }

        AuthenticationResponse? result = await _usersService.Register(registerRequest);

        if (result == null || result.Success == false) { 
            return BadRequest(result);
        }


        return Ok(result);
    }

    [HttpPost("login")] // POST: api/auth/login
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        // Validate request using FluentValidation
        ValidationResult validationResult = await _loginValidator.ValidateAsync(loginRequest);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.PropertyName + ": " + e.ErrorMessage));
        }

        AuthenticationResponse? result = await _usersService.Login(loginRequest);

            if (result == null || result.Success == false)
            {
                return Unauthorized(result);
            }

            return Ok(result);
    }
}
