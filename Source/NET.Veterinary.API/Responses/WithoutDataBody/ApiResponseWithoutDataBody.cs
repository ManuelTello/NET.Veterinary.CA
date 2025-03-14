using NET.Veterinary.API.Responses.Base;

namespace NET.Veterinary.API.Responses.WithoutDataBody
{
    public record ApiResponseWithoutBody : IApiResponse
    {
        public int StatusCode { get; init; }

        public IDictionary<string, ICollection<string>> ErrorsList { get; init; }

        private ApiResponseWithoutBody(int statusCode, IDictionary<string, ICollection<string>> errorsList)
        {
            this.StatusCode = statusCode;
            this.ErrorsList = errorsList;
        }

        public static ApiResponseWithoutBody Create(int statusCode, IDictionary<string, ICollection<string>> errorsList)
        {
            return new ApiResponseWithoutBody(statusCode, errorsList);
        }
    }