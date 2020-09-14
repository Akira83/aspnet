using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegister) 
        {
            // TODO: validate request

            userForRegister.Username = userForRegister.Username.ToLower();

            if (await _repo.UserExists(userForRegister.Username)) {
                return BadRequest("Username already exist");
            }

            var userToCreate = new User
            { 
                Username = userForRegister.Username 
            };

            var createdUser = await _repo.Register(userToCreate, userForRegister.Password);
        
            return StatusCode(201);
        }
    }
}