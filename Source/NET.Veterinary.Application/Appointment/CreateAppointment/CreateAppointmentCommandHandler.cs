using MediatR;
using NET.Veterinary.Application.Helpers;
using NET.Veterinary.Domain.IRepositories;
using NET.Veterinary.Domain.ObjectValues;

namespace NET.Veterinary.Application.Appointment.CreateAppointment
{
    public class CreateAppointmentCommandHandler(IAppointmentRepository repository) : IRequestHandler<CreateAppointmentCommand, Response<Unit>>
    {
        private readonly IAppointmentRepository _repository = repository;

        public async Task<Response<Unit>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var errors = new Dictionary<string, ICollection<string>>();

            var completeName = CompleteName.Create(request.CompleteName);
            var dateSelected = TimestampNoTimeZone.Create(request.DateSelected);
            var identification = Identification.Create(request.Identification);

            if (completeName.IsFailed)
                errors.Add("CompleteName", [completeName.Errors.First().Message]);

            if (dateSelected.IsFailed)
                errors.Add("DateSelected", [dateSelected.Errors.First().Message]);

            if (identification.IsFailed)
                errors.Add("Identification", [identification.Errors.First().Message]);

            if (errors.Count == 0)
            {
                const bool didAssist = false;
                const int id = 0;
                var appointment = new Domain.AggregateRoots.Appointment.Appointment(id, dateSelected.Value, completeName.Value, identification.Value, didAssist);

                await this._repository.CreateAppointmentAsync(appointment);
                await this._repository.SaveChangesAsync(cancellationToken);

                return Response<Unit>.Create(Unit.Value, errors, true);
            }
            else
            {
                return Response<Unit>.Create(Unit.Value, errors, false);
            }
        }
    }
}