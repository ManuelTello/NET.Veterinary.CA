using MediatR;
using NET.Veterinary.Application.Helpers;

namespace NET.Veterinary.Application.Appointment.UpdateAppointmentAssist
{
    public record UpdateAppointmenAssistCommand(int AppointmentId) : IRequest<Response<Unit>>;
}