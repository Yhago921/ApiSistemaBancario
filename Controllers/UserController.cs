using Api.DTO;
using Api.Models;
using Api.Services.UserS;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : Controller {
        private readonly IUserInterface userInterface;
        public UserController(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }
        [HttpGet("ListarUsers")]
        public async Task<ActionResult<ResponseModel<List<User>>>> ListUser()
        {
            var users = await this.userInterface.ListUser();
            return Ok(users);
        }
        [HttpGet("ListUserById/{userId}")]
        public async Task<ActionResult<ResponseModel<User>>> ListUserById(int userId)
        {
            var user = await this.userInterface.ListUserbyId(userId);
            return Ok(user);
        }
        [HttpPost("createUser")]
        public async Task<ActionResult<ResponseModel<User>>> CreateUser(UserDto userDto)
        {
            var user = await this.userInterface.CreateUser(userDto);
            return Ok(user);
        }

        [HttpDelete("deleteUser/{idUser}")]

        public async Task<ActionResult<ResponseModel<User>>> DeleteUser(int idUser)
        {
          var user = await this.userInterface.DeleteUserById(idUser);
          return Ok(user);  
        }
    }
}