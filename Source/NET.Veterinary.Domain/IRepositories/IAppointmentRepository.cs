using NET.Veterinary.Domain.AggregateRoots.Appointment;

namespace NET.Veterinary.Domain.IRepositories
{
    public interface IAppointmentRepository:IDisposable
    {
        public Task CreateAppointmentAsync(Appointment appointment);

        public Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}

