using Microsoft.AspNetCore.Mvc;
using Test.BL.Interfaces;

namespace Test.Presentation.Controllers
{
    [Route("api/{controller}")]
    public class ValuesController : Controller
    {
        private readonly ICheckDataService _checkDataService;
        public ValuesController(ICheckDataService checkDataService)
        {
            _checkDataService = checkDataService;
        }

        [HttpGet("CheckValue")]
        public IActionResult CheckValue([FromBody] string data)
        {
            var result = _checkDataService.CheckValue(data);

            return Ok(result);
        }
    }
}
