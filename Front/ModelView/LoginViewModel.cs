using System.ComponentModel.DataAnnotations;

namespace Front.ModelView;

public class LoginViewModel
{
    [Required(ErrorMessage = "É preciso informar o e-mail para continuar.")]
    [EmailAddress(ErrorMessage = "É preciso informar um e-mail válido para continuar")]
    public string Email { get; set; }
    [Required(ErrorMessage = "É preciso informar a senha para continuar")]
    public string Password { get; set; }
}
