using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Features.User.Commands.Login;
using TaskManager.Application.Features.User.Commands.Register;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            var response = await mediator.Send(request);
            if (response.IsSuccessed)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }


    }
}
