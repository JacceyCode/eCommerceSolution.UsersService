using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }


        // GET: api/users/{userID}
        [HttpGet("{userID:guid}")]
        public async Task<ActionResult> GetUserByUserID(Guid userID)
        {
            if(userID == Guid.Empty)
            {
                return BadRequest("Invalid userID");
            }

            UserDTO user = await _usersService.GetUserByUserID(userID);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
