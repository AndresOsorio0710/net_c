
using Authentication.Backend.Aplications.Services.Users;
using Authentication.Backend.Domain.Models;
using Authentication.Backend.Domain.Referentials;
using Authentication.Backend.Infrastructure.Data.Contexts;
using Authentication.Backend.Infrastructure.Data.Repositories.Users;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Backend.Infrastructure.API.Controllers.UserController
{
    public class UserController : ApiController
    {
        private readonly UserService userService;

        public UserController()
        {
            BackendContext backendContext = new BackendContext();
            UserRepository userRepository = new UserRepository(backendContext);
            this.userService = new UserService(userRepository);
        }

        private UserService CreateUserService(UserService userService)
        {
            
            return userService;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [Produces("application/json", Type = typeof(TransactionResponse<User>))]
        [HttpPost("Add")]
        public IActionResult Add([FromBody]User user)
        {
            TransactionResponse<User> response = this.userService.Add(user);
            return Ok(response);
        }
    }
}
