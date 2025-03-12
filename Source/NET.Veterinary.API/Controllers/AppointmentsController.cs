using MediatR;
using Microsoft.AspNetCore.Mvc;
using NET.Veterinary.API.Contracts.Appointment;
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
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointment contract)
        {
            var command = new CreateAppointmentCommand(contract.CompleteName, contract.DateSelected, contract.Identification);
            var result = await this._mediator.Send(command);
            return Ok();
        }
    }
}
