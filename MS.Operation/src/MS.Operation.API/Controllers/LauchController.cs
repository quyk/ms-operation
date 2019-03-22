using Microsoft.AspNetCore.Mvc;
using MS.Operation.Application.Streaming;
using MS.Operation.Domain.Entities;

namespace MS.Operation.API.Controllers
{
    [Route("api/lauch")]
    [ApiController]
    public class LauchController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="launch"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Launch launch)
        {
            var schema = JsonSchema<Launch>.IsValid(launch, "launch-schema.json");
            if (schema.valid)
            {
                return new CreatedResult("", launch);
            }

            return new ConflictObjectResult(schema.mesage);
        }
    }
}
