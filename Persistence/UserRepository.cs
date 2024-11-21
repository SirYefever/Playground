using Core.InterfaceContracts;
using Core.Models;

namespace Persistence;

public class UserRepository: IUserStore
{
    private readonly SampleDbContext _context; 
    public UserRepository(SampleDbContext context)
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