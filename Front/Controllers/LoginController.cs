using Front.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers;

public class LoginController : Controller
{

    public IActionResult Index() => View();
    [HttpPost]
    public IActionResult Login(LoginViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                     .Select(e => e.ErrorMessage)
                                     .ToList();
            return BadRequest(errors);
        }

        return Content(viewModel.Email + " | | " + viewModel.Password);
    }
}
