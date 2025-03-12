using MediatR;

namespace NET.Veterinary.Application.Appointment.CreateAppointment
{
    public record CreateAppointmentCommand(string CompleteName, string DateSelected, int Identification):IRequest<Unit>;
}

