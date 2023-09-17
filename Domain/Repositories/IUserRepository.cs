using Domain.Model;
using System.Collections;

namespace Domain.Repositories;

public interface IUserRepository
{

    public IList<User> FindAll();
}
