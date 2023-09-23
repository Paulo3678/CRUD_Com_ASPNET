using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.User;

public record UpdatePasswordDto
{
    [Required(ErrorMessage = "É preciso informar a senha antiga para continuar.")]
    public string OldPassword { get; set; }
    [Required(ErrorMessage = "É preciso informar a nova senha para continuar")]
    [MinLength(8, ErrorMessage = "A senha deve conter pelo menos 8 caracteres.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$", ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.")]
    public string NewPassword { get; set; }
    [Required(ErrorMessage = "É preciso confirmar a nova senha para continuar.")]
    [Compare("NewPassword", ErrorMessage = "As senhas não são iguais.")]
    public string ConfirmPassword { get; set; }

}
