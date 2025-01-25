using Microsoft.AspNetCore.Mvc;
using PersonalDiary.Application.Feature.Places.CulturePlaces;

namespace PersonalDiary.Api.Controllers.PlaceControllers
{
    [ApiController]
    [Route("api/culturePlace")]
    public class CulturePlacesController : BaseValidatedController
    {

        [HttpPost]
        public async Task<IActionResult> CreateCulturePlace([FromBody] Create.Command command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> DetailsOfCulturePlace(Guid id)
        {
            return Ok(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCulturePlace(Guid id)
        {

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> PagedList([FromQuery] PagedList.Query query)
        {
            return Ok(await Mediator.Send(query));
        }
        //[Authorize]
        //[HttpPost("review")]
        //public async Task<IActionResult> CreateReviewOfPlace([FromBody] CreateReview.Command command)
        //{
        //    var id = await Mediator.Send(command);
        //    return Ok(id);
        //}
        //[HttpGet("review")]
        //public async Task<IActionResult> GetRewievOfPlace([FromQuery] ReviewList.Query query)
        //{
        //    var list = await Mediator.Send(query);
        //    return Ok(list);
        //}
    }
}
