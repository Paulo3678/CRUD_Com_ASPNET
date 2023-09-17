using Domain.Model;
using Microsoft.AspNetCore.Identity;

namespace Domain.Repositories;

public class UserEloquentRepository : IUserRepository
{
    public IList<User> FindAll()
    {
        List<User> users = new List<User>();
        users.Add(new User(1, "Nome1", "email@email.com", "batman"));
        users.Add(new User(2, "Nome2", "teste@email.com", "robin"));

        return users;
    }
}
