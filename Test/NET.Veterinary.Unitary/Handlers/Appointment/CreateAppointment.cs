using System.Globalization;
using Moq;
using NET.Veterinary.Application.Appointment.CreateAppointment;
using NET.Veterinary.Domain.IRepositories;

namespace NET.Veterinary.Unitary.Handlers.Appointment
{
    public class CreateAppointment
    {
        [Fact]
        public async Task CreateAppointment_ShouldReturnUnit()
        {
            var repositoryMock = new Mock<IAppointmentRepository>();
            var handler = new CreateAppointmentCommandHandler(repositoryMock.Object);
            var command = new CreateAppointmentCommand("John Doe", DateTime.Now.ToString(CultureInfo.InvariantCulture), 40000000);
            await handler.Handle(command, CancellationToken.None);
            repositoryMock.Verify(repo => repo.CreateAppointmentAsync(It.IsAny<Domain.AggregateRoots.Appointment.Appointment>()), Times.Once);
        }
    }
}