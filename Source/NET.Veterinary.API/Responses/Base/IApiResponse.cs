namespace NET.Veterinary.API.Responses.Base
{
    public interface IApiResponse
    {
        public int StatusCode { get; init; }

        public IDictionary<string, ICollection<string>> ErrorsList { get; init; }
    }
}