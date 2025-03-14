using MediatR;
using Microsoft.AspNetCore.Mvc;
using NET.Veterinary.API.Contracts.Appointment;
using NET.Veterinary.API.Responses.WithoutDataBody;
using NET.Veterinary.Application.Appointment.CreateAppointment;

namespace NET.Veterinary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        [Route("[action]")]
        [Produces("application/json")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointment contract)
        {
            try
            {
                var command = new CreateAppointmentCommand(contract.CompleteName, contract.DateSelected, contract.Identification);
                var result = await this._mediator.Send(command);
                if (result.IsSuccess)
                {
                    return Ok(ApiResponseWithoutBody.Create(StatusCodes.Status200OK, result.Errors));
                }
                else
                {
                    return BadRequest(ApiResponseWithoutBody.Create(StatusCodes.Status400BadRequest, result.Errors));
                }
            }
            catch (ApplicationException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPatch]
        [Route("[action]")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateAppointmentAssist()
        {
            return Ok();
        }
    }
}
