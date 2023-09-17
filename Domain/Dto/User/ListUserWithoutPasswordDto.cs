namespace Domain.Dto.User;

public record ListUserWithoutPasswordDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public ListUserWithoutPasswordDto() { }

    public ListUserWithoutPasswordDto(CreateNewUserDto dto)
    {
        Name = dto.Name;
        Email = dto.Email;
    }
}
