using Core.InterfaceContracts;
using Core.Models;

namespace Persistence;

public class UserRepository: IUserStore
{
    public Task Add(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}