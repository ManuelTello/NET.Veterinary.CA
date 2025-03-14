using NET.Veterinary.API.Responses.Base;

namespace NET.Veterinary.API.Responses.WithDataBody
{
    public record ApiResponseWithBody<T> : IApiResponse
    {
        public int StatusCode { get; init; }

        public IDictionary<string, ICollection<string>> ErrorsList { get; init; }

        public T Body { get; init; }

        private ApiResponseWithBody(int statusCode, IDictionary<string, ICollection<string>> errorsList, T body)
        {
            this.StatusCode = statusCode;
            this.ErrorsList = errorsList;
            this.Body = body;
        }

        public static ApiResponseWithBody<T> Create(int statusCode, IDictionary<string, ICollection<string>> errorsList, T body)
        {
            return new ApiResponseWithBody<T>(statusCode, errorsList, body);
        }
    }
}