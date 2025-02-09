using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Entities;
using WebApplication1.Ingreso;
namespace WebApplication1.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserDBController : ControllerBase
    {
        private readonly UserDBContext _userDBContext;
        public UserDBController(UserDBContext userDBContext)
        {
            _userDBContext = userDBContext;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userDBContext.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }

        [HttpGet]
        public Task<IActionResult> Get()
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(User))]
        public async Task<IActionResult> Post([FromBody] UserDto newUser)
        {
            if (newUser != null)
            {
                var response = await _userDBContext.Post(newUser);
                return new CreatedResult($"https://localhost:7208/api/UserDB/{response.Id}", null);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();    
        }
    }
}
