using Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.User;

public record CreateNewUserDto
{
    [Required(ErrorMessage = "É preciso informar um nome para continuar!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "É preciso informar um e-mail para continuar!")]
    [EmailAddress(ErrorMessage = "É preciso informar um e-mail válido para continuar!")]
    public string Email { get; set; }
    [Required(ErrorMessage = "É preciso informar uma senha para continuar")]
    [MinLength(8, ErrorMessage = "A senha deve conter pelo menos 8 caracteres.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$", ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.")]
    public string Password { get; set; }
    [Required(ErrorMessage = "É preciso confirmar a senha!")]
    [Compare("Password", ErrorMessage = "As senhas não são iguais")]
    public string ConfirmPassword { get; set; }
    [Required(ErrorMessage = "É preciso informar a permissão do usuário para continuar!")]
    [EnumDataType(typeof(UserRolesEnum), ErrorMessage = "O campo role só recebe os valores ADMIN(1) ou NORMAL(2)")]
    public UserRolesEnum Role { get; set; }
}
