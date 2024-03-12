using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Interfaces.Repositories.Duty;
using MediatR;
using TaskManager.Application.Features.Duty.Queries.GetAllDuties;
using TaskManager.Application.Features.Duty.Commands.CreateDuty;
using TaskManager.Application.Features.Duty.Commands.UpdateDuty;
using TaskManager.Application.Features.Duty.Commands.DeleteDuty;
using TaskManager.Application.Features.Duty.Commands.CompleteTask;
using TaskManager.Application.Features.Duty.Queries.GetAllDutiesByPaging;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Authorization;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableRateLimiting("Basic")]
    [Authorize]
    public class DutyController : ControllerBase
    {
        private readonly IMediator mediator;
     
        public DutyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDuties([FromQuery] GetAllDutiesQueryRequest request)
        {
            var duties = await mediator.Send(request);
            return Ok(duties);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDutiesByPaging([FromQuery] GetAllDutiesByPagingQueryRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDuty(CreateDutyCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDuty(UpdateDutyCommandRequest request)
        {
           var response = await mediator.Send(request);

            if (response.isSuccessed)
                return Ok();
            else 
                return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> CompleteTask([FromQuery] CompleteDutyCommandRequest request)
        {
            CompleteDutyCommandResponse response = await mediator.Send(request);
            if (response.IsSuccessed) return Ok();
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDuty([FromQuery] DeleteDutyCommandRequest request)
        {
            DeleteDutyCommandResponse response =  await mediator.Send(request);
            
            if(response.IsSuccessed) return Ok();
            return BadRequest();
        }
     
        
    }
}
