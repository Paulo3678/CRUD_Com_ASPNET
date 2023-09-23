using Domain.Dto.User;
using Domain.Model;
using System.Collections;

namespace Domain.Repositories;

public interface IUserRepository
{
    public IList<User> FindAll();
    public User FindById(int id);
    public User FindByEmail(string email);
    public ListUserWithoutPasswordDto Create(CreateNewUserDto dto);
    public void UpdateUserPassword(UpdatePasswordDto dto, User userToUpdate);
    public void UpdateUserInfos(UpdateUserInfoDto dto, string userEmail);
}
