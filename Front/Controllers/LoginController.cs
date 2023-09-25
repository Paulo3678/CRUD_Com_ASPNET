using Front.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers;

public class LoginController : Controller
{

    public IActionResult Index() => View();
    [HttpPost]
    public IActionResult Login(LoginViewModel viewModel)
    {
        return Content(viewModel.Email + " | | " + viewModel.Password);
    }
}
