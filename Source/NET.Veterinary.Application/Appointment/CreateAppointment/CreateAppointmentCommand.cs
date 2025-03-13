using MediatR;
using NET.Veterinary.Application.Helpers;

namespace NET.Veterinary.Application.Appointment.CreateAppointment
{
    public record CreateAppointmentCommand(string CompleteName, string DateSelected, int Identification):IRequest<Response<Unit>>;
}

