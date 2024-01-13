using ArchiWorkshop.Domains.Abstractions.Errors;

namespace ArchiWorkshop.Domains.Abstractions.Results;

public interface IValidationResult
{
    Error[] ValidationErrors { get; }
}