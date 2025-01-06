using Microsoft.AspNetCore.Mvc;
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
    }
}
