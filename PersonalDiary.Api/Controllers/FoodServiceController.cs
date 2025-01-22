using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PersonalDiary.Application.Feature.Food;

namespace PersonalDiary.Api.Controllers
{
    [ApiController]
    [Route("api/food")]
    public class FoodServiceController : BaseValidatedController
    {
        [HttpPost]
        public async Task<IActionResult> CreateFoodPlace([FromBody] Create.Command command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> DetailsOfTask(Guid id)
        {
            return Ok(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> PagedList([FromQuery] PagedList.Query query)
        {
            return Ok(await Mediator.Send(query));
        }
        [Authorize]
        [HttpPost("review")]
        public async Task<IActionResult> CreateReviewOfPlace([FromBody] CreateReview.Command command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }
        [HttpGet("review")]
        public async Task<IActionResult> GetRewievOfPlace([FromQuery] ReviewList.Query query)
        {
            var list = await Mediator.Send(query);
            return Ok(list);
        }
    }
}
