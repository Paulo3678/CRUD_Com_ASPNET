using Front.ModelView;
using Front.Services.ApiRequest;
using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers;

public class LoginController : Controller
{
    private LoginApiRequest _request;

    public LoginController(LoginApiRequest request)
    {
        _request = request;
    }
    public IActionResult Index(IList<string> errors = null)
    {
        LoginViewModel vm = new LoginViewModel();
        if (errors != null)
        {
            vm.Errors = errors;
        }
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel viewModel)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                         .Select(e => e.ErrorMessage)
                                         .ToList();
                return RedirectToAction("Index", new { errors });
            }
            var token = await _request.Login(viewModel);
            HttpContext.Session.SetString("token", token);
            return RedirectToAction("Index"); ;
        }
        catch (Exception)
        {
            LoginViewModel vm = new LoginViewModel();
            List<string> errors= new List<string>();
            errors.Add("E-mail ou senha");  

            vm.Errors = errors;
            return RedirectToAction("Index", new { errors });
        }
    }
}
