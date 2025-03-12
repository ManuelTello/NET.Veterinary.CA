using FluentResults;

namespace NET.Veterinary.Domain.ObjectValues
{
    public partial record Identification
    {
        public int Value { get; init; }

        private Identification(int value)
        {
            this.Value = value;
        }

        public static Result<Identification> Create(int value)
        {
            return Result.Ok<Identification>(new Identification(value));
        }
    }
}

