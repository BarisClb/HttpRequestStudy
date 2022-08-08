using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResponseAPI.Service;
using Shared;

namespace ResponseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        ResponseService _responseService;

        public ResponseController(ResponseService responseService)
        {
            _responseService = responseService;
        }


        [HttpGet("GetResponse")]
        public async Task<IActionResult> GetResponse([FromQuery]PasswordRequest passwordRequest)
        {
            return Ok(await _responseService.GeneratePassword(passwordRequest));
        }
    }
}
