using Domain.Dto.User;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Domain.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private IUserRepository _repository;

    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [Route("create")]
    public IActionResult Create(CreateNewUserDto dto)
    {
        try
        {
            var createdUser = _repository.Create(dto);
            return Ok(createdUser);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [Authorize]
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetInfos([FromRoute] int id)
    {
        try
        {
            var user = _repository.FindById(id);
            var tokenEmail = HttpContext.User.FindFirst("Email");

            if (user.Email != tokenEmail.Value)
            {
                return Unauthorized(new { message = "Você não pode acessar as informações de outro usuário." });
            }

            return Ok(new ListUserWithoutPasswordDto(user));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [Authorize]
    [HttpPatch]
    public IActionResult UpdatePassword()
    {
        return Ok();
    }

}
