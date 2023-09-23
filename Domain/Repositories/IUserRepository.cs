using Domain.Dto.User;
using Domain.Model.User;
using System.Collections;

namespace Domain.Repositories;

public interface IUserRepository
{
    public IList<ListUserWithoutPasswordDto> FindAll(bool paginated = false, int page = 0);
    public User FindById(int id);
    public User FindByEmail(string email);
    public ListUserWithoutPasswordDto Create(CreateNewUserDto dto);
    public void UpdateUserPassword(UpdatePasswordDto dto, User userToUpdate);
    public void UpdateUserInfos(UpdateUserInfoDto dto, string userEmail);
    public void Delete(int id);

}
