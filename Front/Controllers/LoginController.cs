using Front.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers;

public class LoginController : Controller
{

    public IActionResult Index(IList<string> errors = null)
    {
        if (errors != null)
        {
            ViewBag.Errors = errors;
        }
        //var sessao = HttpContext.Session.GetString("NOME");
        //Console.WriteLine(sessao);

        return View();
    }


    [HttpPost]
    public IActionResult Login(LoginViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                     .Select(e => e.ErrorMessage)
                                     .ToList();
            return RedirectToAction("Index", new { errors });
        }

        return RedirectToAction("Index");
    }
}
