using Domain.Data;
using Domain.Dto.User;
using Domain.Model.User;
using Microsoft.AspNetCore.Identity;

namespace Domain.Repositories;

public class UserEloquentRepository : IUserRepository
{
    private readonly DomainAppDbContext _context;
    private readonly PasswordHasher<User> _passwordHasher;
    public UserEloquentRepository(DomainAppDbContext context)
    {
        _context = context;
        _passwordHasher = new PasswordHasher<User>();
    }

    public IList<User> FindAll()
    {
        List<User> users = new List<User>();
        //users.Add(new User("Nome1", "email@email.com", "batman"));
        //users.Add(new User("Nome2", "teste@email.com", "robin"));

        return users;
    }
    public User FindById(int id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        if (user == null)
        {
            throw new ArgumentException("Usuário não existe no sistema");
        }
        return user;
    }
    public User FindByEmail(string email)
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == email);
        if (user == null)
        {
            throw new ArgumentException("Usuário não existe no sistema");
        }
        return user;
    }
    public ListUserWithoutPasswordDto Create(CreateNewUserDto dto)
    {
        var userEmailAlreadyExists = _context.Users.FirstOrDefault(u => u.Email == dto.Email);

        if (userEmailAlreadyExists != null)
        {
            throw new ArgumentException("E-mail já cadastrado no nosso sistema.");
        }
        User user = new User(
            dto.Name,
            dto.Email,
            _passwordHasher.HashPassword(null, dto.Password),
            dto.Role
        );

        _context.Users.Add(user);
        _context.SaveChanges();
        return new ListUserWithoutPasswordDto(dto);

    }
    public void UpdateUserPassword(UpdatePasswordDto dto, User userToUpdate)
    {
        try
        {
            userToUpdate.Password = _passwordHasher.HashPassword(null, dto.NewPassword);
            _context.Users.Update(userToUpdate);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw new Exception("Erro ao tentar atualizar senha. Tente novamente mais tarde");
        }
    }
    public void UpdateUserInfos(UpdateUserInfoDto dto, string userEmail)
    {
        try
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado no sistema");
            }
            user.Name = dto.Name;
            user.Email = dto.Email;

            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw new Exception("Erro ao tentar atualizar dados do usuário");
        }
    }

    public void Delete(int id)
    {
        try
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new ArgumentException("Usuário não encontrado no sistema");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        catch (ArgumentException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (Exception)
        {
            throw new Exception("Erro ao tentar remover usuário! Tente novamente mais tarde");
        }
    }
}
