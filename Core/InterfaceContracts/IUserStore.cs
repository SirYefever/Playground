using Core.Models;

namespace Core.InterfaceContracts;

public interface IUserStore
{
    Task Add(User user);
    Task<User> GetById(Guid id);
}