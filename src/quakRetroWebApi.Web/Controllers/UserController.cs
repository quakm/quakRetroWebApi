using Microsoft.AspNetCore.Mvc;
using quakRetroWebApi.Core.Entities;
using quakRetroWebApi.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;

namespace quakRetroWebApi.Web.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserRepository userRepository) : ControllerBase
{
    private readonly IUserRepository _userRepository = userRepository;

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}


