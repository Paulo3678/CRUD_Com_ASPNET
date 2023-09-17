using Domain.Dto.User;
using Domain.Model;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers;

[ApiController]
[Route("api")]
public class LoginController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public LoginController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] UserLoginDto dto, [FromServices] JwtTokenService jwtToken)
    {
        try
        {
            User user = _userRepository.FindByEmail(dto.Email);
            return Ok(new { token = jwtToken.Generate(user) });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
