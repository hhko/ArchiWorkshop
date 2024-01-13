using ArchiWorkshop.Domains.Abstractions.Errors;

namespace ArchiWorkshop.Domains.Abstractions.Results;

public class Result : IResult
{
    private static readonly Result _success = new(Error.None);

    private protected Result(Error error)
    {
        Error = error;
    }

    public bool IsSuccess => Error == Error.None;

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    public static Result Create(bool condition)
    {
        return condition
            ? Success()
            : Failure(Error.ConditionNotSatisfied);
    }

    public static Result<TValue> Create<TValue>(TValue? value)
    {
        if (value is null)
        {
            return Failure<TValue>(Error.NullValue);
        }

        if (value is Error)
        {
            throw new InvalidOperationException("Provided value is an Error");
        }

        return Success(value);
    }

    public static Result Success()
    {
        return _success;
    }

    public static Result<TValue> Success<TValue>(TValue value)
    {
        return new Result<TValue>(value, Error.None);
    }

    public static Result Failure(Error error)
    {
        error.ThrowIfErrorNone();
        return new Result(error);
    }

    public static Result<TValue> Failure<TValue>(Error error)
    {
        error.ThrowIfErrorNone();
        return new Result<TValue>(default, error);
    }

    //public Result<TValue> Failure<TValue>()
    //{
    //    return Failure<TValue>(Error);
    //}

    //public static Result<TValue> BatchFailure<TValue>(TValue value)
    //{
    //    return new Result<TValue>(value, Error.None);
    //}
}

public class Result<TValue> : Result, IResult<TValue>
{
    private readonly TValue? _value;

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException($"The value of a failure result can not be accessed. Type '{typeof(TValue).FullName}'.");

    protected internal Result(TValue? value, Error error)
        : base(error)
    {
        _value = value;
    }

    public static implicit operator Result<TValue>(TValue? value)
    {
        return Create(value);
    }
}