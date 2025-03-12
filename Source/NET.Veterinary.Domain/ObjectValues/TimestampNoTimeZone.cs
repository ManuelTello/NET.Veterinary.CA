using FluentResults;

namespace NET.Veterinary.Domain.ObjectValues
{
    public partial record TimestampNoTimeZone
    {
        public string Value { get; init; }

        private TimestampNoTimeZone(string value)
        {
            this.Value = value;
        }

        public static Result<TimestampNoTimeZone> Create(string value)
        {
            return Result.Ok<TimestampNoTimeZone>(new TimestampNoTimeZone(value));
        }
    }
}

