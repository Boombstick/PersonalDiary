using Microsoft.AspNetCore.Mvc;
using PersonalDiary.Application.Feature.City.Places.WalkPlaces;

namespace PersonalDiary.Api.Controllers.PlaceControllers
{
    [ApiController]
    [Route("api/walkPlace")]
    public class WalkPlaceController : BaseValidatedController
    {
        [HttpPost]
        public async Task<IActionResult> CreateWalkPlace([FromBody] Create.Command command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> DetailsOfWalkPlace(Guid id)
        {
            return Ok(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWalkPlace(Guid id)
        {

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> PagedListWalkPlace([FromQuery] PagedList.Query query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
