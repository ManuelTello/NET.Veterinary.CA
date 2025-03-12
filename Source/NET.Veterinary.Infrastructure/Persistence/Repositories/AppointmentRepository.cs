using NET.Veterinary.Domain.AggregateRoots.Appointment;
using NET.Veterinary.Domain.IRepositories;
using NET.Veterinary.Infrastructure.Persistence.Context;

namespace NET.Veterinary.Infrastructure.Persistence.Repositories
{
    public class AppointmentRepository:IAppointmentRepository
    {
        private readonly ApplicationContext _context;
        
        private bool _disposed = false;

        public AppointmentRepository(ApplicationContext context)
        {
           this._context = context; 
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }
            
            this._disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task CreateAppointmentAsync(Appointment appointment)
        {
            await this._context.Appointments.AddAsync(appointment);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await this._context.SaveChangesAsync(cancellationToken);
        }
    }
}

