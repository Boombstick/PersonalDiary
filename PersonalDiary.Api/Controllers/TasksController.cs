using Microsoft.AspNetCore.Mvc;
using PersonalDiary.Application.Feature.Tasks;

namespace PersonalDiary.Api.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : BaseValidatedController
    {
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] Create.Command command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> DetailsOfTask(long id)
        {
            return Ok(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPut]
        public async Task<IActionResult> TaskChangeStatus([FromBody] ChangeStatus.Command command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(long id)
        {
            await Mediator.Send(new Delete.Command { Id = id });
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> PagedList([FromQuery] PagedList.Query query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
