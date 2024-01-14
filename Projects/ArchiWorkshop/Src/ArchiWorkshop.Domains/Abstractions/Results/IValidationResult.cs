namespace ArchiWorkshop.Domains.Abstractions.Results;

public interface IValidationResult
{
    Error[] ValidationErrors { get; }
}