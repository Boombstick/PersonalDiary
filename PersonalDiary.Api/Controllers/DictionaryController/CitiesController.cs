using Microsoft.AspNetCore.Mvc;
using PersonalDiary.Application.Feature.Dictionaries.Cities;

namespace PersonalDiary.Api.Controllers.DictionaryController
{
    public partial class DictionaryController
    {
        [HttpGet("cities")]
        public async Task<IActionResult> ListOfCities()
        {
            return Ok(await Mediator.Send(new List.Query()));
        }
    }
}
