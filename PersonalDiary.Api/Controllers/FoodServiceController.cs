using Microsoft.AspNetCore.Mvc;
using PersonalDiary.Application.Feature.Food;

namespace PersonalDiary.Api.Controllers
{
    [ApiController]
    [Route("api/food")]
    public class FoodServiceController : BaseValidatedController
    {
        [HttpPost]
        public async Task<IActionResult> CreateFoodPlace(Create.Command command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }
        [HttpGet]
        public async Task<IActionResult> DetailsOfTask(Guid id)
        {
            return Ok(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPut]
        public async Task<IActionResult> TaskChangeStatus()
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTask()
        {
            return Ok();
        }

    }
}
