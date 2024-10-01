using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using quakRetroWebApi.Core.Dtos.Users;
using quakRetroWebApi.Core.Entities;
using quakRetroWebApi.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;

namespace quakRetroWebApi.Web.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserRepository userRepository, IMapper mapper) : ControllerBase
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;

    [HttpGet("{id}")]
    public async Task<ActionResult<UserEntity>> GetUser(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user == null)
            return NotFound();


        return Ok(_mapper.Map<UserDto>(user));
    }

}


