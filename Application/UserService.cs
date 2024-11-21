using Core.InterfaceContracts;
using Core.Models;
using Core.ServiceContracts;

namespace Application;

public class UserService : IUserService
{
    private readonly IUserStore _userStore;

    public UserService(IUserStore userStore)
    {
        _userStore = userStore;
    }
    // Service is a middle layer between controller and repository. it's supposed to manage console logging,
    // validation(that's not related to DB(whatever that means)) TODO: delete this comment


    public Task<User> GetUserById(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<User> CreateUser(User user)
    {
        // Console logging is supposed to be here
        //TODO: figure out weather token generation is supposed to be here
        var token = TokenService.GenerateAccessToken(user.Email);
        user.Token = token;
        await _userStore.Add(user);
        return user;
    }

    public Task<User> UpdateUser(User userToBeUpdated, User updatedUser)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteUser(User user)
    {
        throw new NotImplementedException();
    }
}