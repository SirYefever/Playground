using Core.InterfaceContracts;
using Core.Models;
using Persistence;

namespace Persistence;

public class UserRepository: IUserStore
{
    private readonly MainDbContext _context; 
    public UserRepository(MainDbContext context)
    {
        _context = context;
    }
    public Task Add(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}