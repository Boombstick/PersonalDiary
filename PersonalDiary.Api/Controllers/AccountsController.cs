using Microsoft.AspNetCore.Mvc;
using PersonalDiary.Application.Feature.Accounts;

namespace PersonalDiary.Api.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : BaseValidatedController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register.Command command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login.Command command)
        {
            var token = await Mediator.Send(command);
            return Ok(token);
        }
    }
}
