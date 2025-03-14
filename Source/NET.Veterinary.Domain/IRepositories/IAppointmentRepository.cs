using NET.Veterinary.Domain.AggregateRoots.Appointment;

namespace NET.Veterinary.Domain.IRepositories
{
    public interface IAppointmentRepository : IDisposable
    {
        public Task CreateAppointmentAsync(Appointment appointment);

        public Task<Appointment?> FetchAppointmentById(int id);

        public Task UpdateAppointmentAssist(int id);

        public Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}

