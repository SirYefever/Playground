using Playground2.Entity;

namespace Playground2.Temp;

public class UserConverters
{
    public User UserDtoToUser(UserDto dto)
    {
        var user = new User();
        user.FullName = dto.FullName;
        user.Email = dto.Email;
        user.Password = dto.Password;
        user.BirthDate = dto.BirthDate;
        user.Gender = dto.Gender;
        user.PhoneNumber = dto.PhoneNumber;
        return user;
    }

    public User UserRegisterModelToUser(UserRegisterModel model)
    {
        var user = new User();
        user.FullName = model.FullName;
        user.Email = model.Email;
        user.Password = model.Password;
        user.BirthDate = model.BirthDate;
        user.Gender = model.Gender;
        user.PhoneNumber = model.PhoneNumber;
        return user;
    }

    public UserDto UserToUserDto(User user)
    {
        var userDto = new UserDto();
        userDto.Id = user.Id;
        userDto.FullName = user.FullName;
        userDto.Email = user.Email;
        userDto.Password = user.Password;
        userDto.BirthDate = user.BirthDate;
        userDto.Gender = user.Gender;
        userDto.PhoneNumber = user.PhoneNumber;
        return userDto;
    }

    public UserDto UserRegisterModelToUserDto(UserRegisterModel model)
    {
        var userDto = new UserDto();
        userDto.FullName = model.FullName;
        userDto.Email = model.Email;
        userDto.Password = model.Password;
        userDto.BirthDate = model.BirthDate;
        userDto.Gender = model.Gender;
        userDto.PhoneNumber = model.PhoneNumber;
        return userDto;
    }

    public UserRegisterModel UserToUserRegisterModelDto(User user)
    {
        var model = new UserRegisterModel();
        model.FullName = user.FullName;
        model.Email = user.Email;
        model.Password = user.Password;
        model.BirthDate = user.BirthDate;
        model.Gender = user.Gender;
        model.PhoneNumber = user.PhoneNumber;
        return model;
    }

    public UserRegisterModel UserDtoToUserRegisterModelDto(UserDto dto)
    {
        var model = new UserRegisterModel();
        model.FullName = dto.FullName;
        model.Email = dto.Email;
        model.Password = dto.Password;
        model.BirthDate = dto.BirthDate;
        model.Gender = dto.Gender;
        model.PhoneNumber = dto.PhoneNumber;
        return model;
    }
    
}