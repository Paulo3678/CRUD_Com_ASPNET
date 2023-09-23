using Domain.Dto.User;
using Domain.Model.User;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers;

[ApiController]
[Route("api")]
public class LoginController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordHasher<User> _passwordHasher;
    public LoginController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _passwordHasher = new PasswordHasher<User>();
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] UserLoginDto dto, [FromServices] JwtTokenService jwtToken)
    {
        try
        {
            User user = _userRepository.FindByEmail(dto.Email);

            var passwordIsValid = _passwordHasher.VerifyHashedPassword(user,
                  user.Password,
                  dto.Password
            );

            if (passwordIsValid != PasswordVerificationResult.Success)
            {
                return Unauthorized(new {message="A senha informada não é válida."});
            }

            return Ok(new { token = jwtToken.Generate(user) });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
