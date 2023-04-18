using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserService;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            UserServiceClient client = new UserServiceClient();

            // Calling the WCF service:
            var result = await client.GetAsync();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            UserServiceClient client = new UserServiceClient();

            var result = await client.GetUserByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDto userDto)
        {
            UserServiceClient client = new UserServiceClient();

            var result = await client.InsertUserAsync(userDto);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UserDto userDto)
        {
            UserServiceClient client = new UserServiceClient();

            await client.UpdateUserAsync(userDto);

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            UserServiceClient client = new UserServiceClient();

            await client.DeleteUserAsync(id);

            return Ok();
        }
    }
}
