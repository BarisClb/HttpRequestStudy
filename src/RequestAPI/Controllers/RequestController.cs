using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestAPI.Service;
using Shared;

namespace RequestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        RequestService _requestService;

        public RequestController(RequestService requestService)
        {
            _requestService = requestService;
        }


        [HttpPost("SendRequest")]
        public async Task<IActionResult> SendRequest(PasswordRequest passwordrequest)
        {
            return Ok(await _requestService.RequestPassword(passwordrequest));
        }
    }
}
