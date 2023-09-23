using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.User;

public record UpdateUserInfoDto
{
    [Required(ErrorMessage = "É preciso informar um nome para continuar!")]
    [MinLength(3, ErrorMessage = "O nome precisa conter ao menos 3 caracteres")]
    public string Name { get; set; }
    [Required(ErrorMessage = "É preciso informar um e-mail para continuar!")]
    [EmailAddress(ErrorMessage = "É preciso informar um e-mail válido para continuar!")]
    public string Email { get; set; }
}
