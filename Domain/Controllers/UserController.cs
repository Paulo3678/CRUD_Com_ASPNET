﻿using Domain.Dto.User;
using Domain.Model.User;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;

namespace Domain.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private IUserRepository _repository;
    private readonly PasswordHasher<User> _passwordHasher;
    public UserController(IUserRepository repository)
    {
        _repository = repository;
        _passwordHasher = new PasswordHasher<User>();
    }
    [HttpGet]
    [Route("users")]
    [Authorize(Roles = "ADMIN")]
    public IActionResult ListAll([FromQuery] int page = 0)
    {
        var users = _repository.FindAll(true, page);

        return Ok(users);
    }


    [HttpPost]
    [Route("create")]
    [Authorize(Roles = "ADMIN")]
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
    public IActionResult UpdatePassword([FromBody] UpdatePasswordDto dto)
    {
        try
        {
            var tokenEmail = HttpContext.User.FindFirst("Email");
            var user = _repository.FindByEmail(tokenEmail.Value);

            var passwordIsValid = _passwordHasher.VerifyHashedPassword(user,
                  user.Password,
                  dto.OldPassword
            );

            if (passwordIsValid != PasswordVerificationResult.Success)
            {
                throw new ArgumentException("A senha informada é inválida");
            }

            _repository.UpdateUserPassword(dto, user);
            return Ok(new { message = "Senha atualizada com sucesso." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [Authorize]
    [HttpPut]
    public IActionResult UpdateUserInfo([FromBody] UpdateUserInfoDto dto)
    {
        try
        {
            var existAnUserWithNewEmail = _repository.FindByEmail(dto.Email);
            return BadRequest(new { message = "O e-mail informado já é utilizado por outro usuário no sistema." });
        }
        catch (Exception ex)
        {
            try
            {
                var actualEmail = HttpContext.User.FindFirst("Email");
                _repository.UpdateUserInfos(dto, actualEmail.Value);

                return Ok(new { message = "Dados atualizados com sucesso. Gere um novo token para continuar as suas consultas." });
            }
            catch (Exception ec)
            {
                return BadRequest(new { message = ec.Message });
            }

        }

    }

    [Authorize(Roles = "ADMIN")]
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            var tokenEmail = HttpContext.User.FindFirst("Email");
            var user = _repository.FindByEmail(tokenEmail.Value);

            if (user.Id == id)
            {
                return Unauthorized(new { message = "Você não pode excluir a sua conta." });
            }
            _repository.Delete(id);
            return Ok(new { message = "Usuário removido com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}