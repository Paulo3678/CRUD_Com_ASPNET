using System.ComponentModel.DataAnnotations;

namespace Domain.Dto.User;

public record UserLoginDto(
    [Required(ErrorMessage = "É preciso informar o e-mail para continuar!")]
    [EmailAddress(ErrorMessage ="É preciso informar um e-mail válido.")]
    string Email,
    [Required(ErrorMessage = "É preciso informar a senha para continuar!")]
    string Password

);
