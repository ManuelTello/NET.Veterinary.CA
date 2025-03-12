using FluentResults;

namespace NET.Veterinary.Domain.ObjectValues
{
    public partial record CompleteName
    {
        public string Value { get; init; }

        private CompleteName(string value)
        {
            this.Value = value;
        }

        public static Result<CompleteName> Create(string value)
        {
            return Result.Ok<CompleteName>(new CompleteName(value));
        }
    }
}

