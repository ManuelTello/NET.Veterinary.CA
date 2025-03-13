using NET.Veterinary.Application.Appointment.CreateAppointment;

namespace NET.Veterinary.Application.Helpers
{
    public class Response<T>
    {
        public bool IsSuccess { get; init; }

        public ICollection<string> Errors { get; init; }

        public T Value { get; init; }

        private Response(bool isSucess, ICollection<string> errors, T value)
        {
            this.IsSuccess = isSucess;
            this.Errors = errors;
            this.Value = value;
        }

        public static Response<T> Create(bool isSucess, ICollection<string> errors, T value)
        {
            return new Response<T>(isSucess, errors, value);
        }
    }
}