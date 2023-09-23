using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.User;

public record UpdatePasswordDto
{
    [Required(ErrorMessage = "É preciso informar a senha antiga para continuar.")]
    public string OldPassword { get; set; }
    [Required(ErrorMessage = "É preciso informar a nova senha para continuar")]
    public string NewPassword { get; set; }
    [Required(ErrorMessage = "É preciso confirmar a nova senha para continuar.")]
    [Compare("NewPassword", ErrorMessage = "As senhas não são iguais.")]
    public string ConfirmPassword { get; set; }

}
