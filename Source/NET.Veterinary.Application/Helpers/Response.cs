using NET.Veterinary.Application.Appointment.CreateAppointment;

namespace NET.Veterinary.Application.Helpers
{
    public class Response<T>
    {
        public bool IsSuccess { get; init; }

        public IDictionary<string,ICollection<string>> Errors { get; init; }

        public T Value { get; init; }

        private Response(bool isSuccess, IDictionary<string,ICollection<string>> errors, T value)
        {
            this.IsSuccess = isSuccess;
            this.Errors = errors;
            this.Value = value;
        }

        public static Response<T> Create(T value, IDictionary<string,ICollection<string>> errors, bool isSuccess)
        {
            return new Response<T>(isSuccess, errors, value);
        }
    }
}