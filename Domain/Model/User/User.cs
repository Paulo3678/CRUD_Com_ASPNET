namespace Domain.Model.User;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRolesEnum Roles { get; set; }
    public User(){}
    public User(string name, string email, string password, UserRolesEnum role)
    {
        Name = name;
        Email = email;
        Password = password;
        Roles = role;
    }
}
