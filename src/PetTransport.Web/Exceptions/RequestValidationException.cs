using System.Runtime.Serialization;
using FluentValidation.Results;

namespace PetTransport.Application.Exceptions;

[Serializable]
public class RequestValidationException : Exception
{
    public IDictionary<string, string[]> Errors { get; }

    public RequestValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public RequestValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        var failureGroups = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorCode);

        foreach (var failureGroup in failureGroups)
        {
            var propertyName = failureGroup.Key;
            var propertyFailures = failureGroup.ToArray();

            Errors.Add(propertyName, propertyFailures);
        }
    }

    protected RequestValidationException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        Errors = new Dictionary<string, string[]>();
    }
}
