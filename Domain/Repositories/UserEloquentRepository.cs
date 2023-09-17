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

    public User FindById(int id)
    {
        if (id != 1)
        {
            throw new ArgumentException("Usuário não existe no sistema");
        }

        return new User(1, "Nome1", "email@email.com", "batman");

    }

    public User FindByEmail(string email)
    {
        if (email != "email@email.com")
        {
            throw new ArgumentException("Usuário não existe no sistema");
        }

        return new User(1, "Nome1", "email@email.com", "batman");

    }
}
