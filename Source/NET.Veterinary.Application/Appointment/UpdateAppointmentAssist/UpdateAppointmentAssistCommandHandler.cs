using MediatR;
using NET.Veterinary.Application.Helpers;
using NET.Veterinary.Domain.IRepositories;

namespace NET.Veterinary.Application.Appointment.UpdateAppointmentAssist
{
    public class UpdateAppointmenAssistCommandHandler(IAppointmentRepository repository) : IRequestHandler<UpdateAppointmenAssistCommand, Response<Unit>>
    {
        private readonly IAppointmentRepository _repository = repository;

        public async Task<Response<Unit>> Handle(UpdateAppointmenAssistCommand request, CancellationToken cancellationToken)
        {
            var appointment = await this._repository.FetchAppointmentById(request.AppointmentId);
            var errors = new Dictionary<string, ICollection<string>>();

            if (appointment != null)
            {
                await this._repository.UpdateAppointmentAssist(request.AppointmentId);
                return Response<Unit>.Create(Unit.Value, errors, true);
            }
            else
            {
                errors.Add($"AppointmentEntry_{request.AppointmentId}", ["Entry does not exists"]);
                return Response<Unit>.Create(Unit.Value, errors, false);
            }
        }
    }
}