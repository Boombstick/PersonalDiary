using Microsoft.AspNetCore.Mvc;
using PersonalDiary.Application.Feature.City;

namespace PersonalDiary.Api.Controllers
{
    [ApiController]
    [Route("api/city")]
    public class CityController : BaseValidatedController
    {
        [HttpPost]
        public async Task<IActionResult> CreateCityRequest(CreateRequest.Command command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
