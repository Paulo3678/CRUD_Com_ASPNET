using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers;

[ApiController]
[Route("teste")]
public class TesteController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult Teste()
    {
        return Ok(new { message = "ABACATE" });
    }

}
