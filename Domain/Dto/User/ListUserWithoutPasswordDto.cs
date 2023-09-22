using Domain.Model;

namespace Domain.Dto.User;

public record ListUserWithoutPasswordDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ListUserWithoutPasswordDto() { }

    public ListUserWithoutPasswordDto(CreateNewUserDto dto)
    {
        Name = dto.Name;
        Email = dto.Email;
    }

    public ListUserWithoutPasswordDto(Model.User user)
    {
        Id = user.Id;
        Name = user.Name;
        Email = user.Email;
    }
}
