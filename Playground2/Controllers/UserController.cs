using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Net.Http;
using System.ComponentModel.DataAnnotations;
using Playground2.Entity;
using Playground2.Models;

namespace Playground2.Controllers;
public class UserController
{
    private readonly SampleDbContext _context; 
    public UserController(SampleDbContext context)
    {
        _context = context;
    }
    [HttpPost("api/account/register")]
    public async Task<ActionResult<UserRegisterModel>> AddUser(UserRegisterModel userRegModel)
    {
        _context.Users.Add(userRegModel);
        await _context.SaveChangesAsync();

        return userRegModel;
    }
}