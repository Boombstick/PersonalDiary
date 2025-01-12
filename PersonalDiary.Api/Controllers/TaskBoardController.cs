using Microsoft.AspNetCore.Mvc;
using PersonalDiary.Application.Feature.TaskBoards;

namespace PersonalDiary.Api.Controllers
{
    [ApiController]
    [Route("api/taskBoards")]
    public class TaskBoardController : BaseValidatedController
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Create.Command command)
        {
            var taskId = await Mediator.Send(command);
            return CreatedAtRoute(nameof(DetailsOfTask), new { id = taskId }, taskId);
        }
        [HttpGet("{id}", Name = nameof(DetailsOfTask))]
        public async Task<IActionResult> DetailsOfTask(Guid id)
        {
            return Ok(await Mediator.Send(new Details.Query { Id = id }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            await Mediator.Send(new Delete.Command { Id = id });
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] List.Query query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
