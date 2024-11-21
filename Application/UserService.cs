using Core.InterfaceContracts;

namespace Application;

public class UserService
{
    private readonly IUserStore _userStore;

    public UserService(IUserStore userStore)
    {
        _userStore = userStore;
    }
    // Service is a middle layer between controller and repository. it's supposed to manage console logging,
    // validation(that's not related to DB(whatever that means)) TODO: delete this comment
    
    
}