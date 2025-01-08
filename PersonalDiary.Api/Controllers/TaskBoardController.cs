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
        public async Task<IActionResult> List([FromQuery] List.Query query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
