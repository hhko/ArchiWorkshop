using ArchiWorkshop.Domains.Abstractions.Errors;

namespace ArchiWorkshop.Domains.Abstractions.Results;

public interface IResult
{
    bool IsSuccess { get; }

    bool IsFailure { get; }

    Error Error { get; }
}

public interface IResult<out TValue> : IResult
{
    TValue Value { get; }
}
