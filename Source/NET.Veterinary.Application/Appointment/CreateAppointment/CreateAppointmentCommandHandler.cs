using MediatR;
using NET.Veterinary.Domain.AggregateRoots.Appointment;
using NET.Veterinary.Domain.IRepositories;
using NET.Veterinary.Domain.ObjectValues;

namespace NET.Veterinary.Application.Appointment.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Unit>
    {
        private readonly IAppointmentRepository _repository;

        public CreateAppointmentCommandHandler(IAppointmentRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Unit> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            ICollection<string> errors = new List<string>();

            var completeName = CompleteName.Create(request.CompleteName);
            var dateSelected = TimestampNoTimeZone.Create(request.DateSelected);
            var identification = Identification.Create(request.Identification);

            if (completeName.IsFailed)
                errors.Add(completeName.Errors.First().Message);

            if (dateSelected.IsFailed)
                errors.Add(completeName.Errors.First().Message);

            if (identification.IsFailed)
                errors.Add(identification.Errors.First().Message);

            if (errors.Count == 0)
            {
                const bool didAssist = false;
                const int id = 0;
                var appointment = new Domain.AggregateRoots.Appointment.Appointment(id, dateSelected.Value, completeName.Value, identification.Value, didAssist);

                await this._repository.CreateAppointmentAsync(appointment);
                await this._repository.SaveChangesAsync(cancellationToken);
                
                return Unit.Value;
            }
            else
            {
                
            }
        }
    }
}