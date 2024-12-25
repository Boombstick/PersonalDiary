using Microsoft.AspNetCore.Mvc;

namespace PersonalDiary.Api.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : BaseValidatedController
    {
        [HttpPost]
        public async Task<IActionResult> CreateTask()
        {

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> DetailsOfTask()
        {
            return Ok();
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
