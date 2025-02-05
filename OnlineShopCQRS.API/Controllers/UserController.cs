
using Microsoft.AspNetCore.Mvc;
using OnlineShopCQRS.Application.Users.Commands.CreateUser;
using OnlineShopCQRS.Application.Users.Commands.DeleteUser.OnlineShopCQRS.Application.Users.Commands.DeleteUser;
using OnlineShopCQRS.Application.Users.Commands.UpdateUser;
using OnlineShopCQRS.Application.Users.Queries.GetUserById;
using OnlineShopCQRS.Application.Users.Queries.GetUsers;

namespace OnlineShopCQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await Mediator.Send(new GetUserQuery());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var user = await Mediator.Send(new GetUserByIdQuery { UserId = id });
            return user == null ? NotFound($"User with ID {id} not found") : Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var createdUser = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserCommand command)
        {
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await Mediator.Send(new DeleteUserCommand { Id = id });
            return result == 0 ? NotFound() : NoContent();
        }
    }
}
