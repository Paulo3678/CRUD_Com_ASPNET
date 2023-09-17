using Domain.Dto.User;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

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


}
