namespace ArchiWorkshop.Domains.Abstractions.Results;

public class Error : IEquatable<Error>
{
    // 성공 Error 종류
    //  - None : 없음
    public static readonly Error None = new(string.Empty, string.Empty);

    // 실패 Error 종류
    //  - NullValue
    //  - ConditionNotSatisfied
    //  - ValidationError
    public static readonly Error NullValue = new($"{nameof(NullValue)}", "The result value is null.");
    public static readonly Error ConditionNotSatisfied = new($"{nameof(ConditionNotSatisfied)}", "The specified condition was not satisfied.");
    public static readonly Error ValidationError = new($"{nameof(ValidationError)}", "A validation problem occurred.");

    private Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static Error New(string code, string message)
    {
        return new Error(code, message);
    }

    public string Code { get; }

    public string Message { get; }

    public static implicit operator string(Error error)
    {
        return error.Code;
    }

    public bool Equals(Error? other)
    {
        //return other is not null
        //    && Code == other.Code && Message == other.Message;

        if (other is null)
        {
            return false;
        }

        //if (other.GetType() != GetType())
        //{
        //    return false;
        //}

        return Code == other.Code && Message == other.Message;
    }

    public override bool Equals(object? obj)
    {
        //return obj is Error error
        //    && Equals(error);

        if (obj is null)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        if (obj is not Error otherError)
        {
            return false;
        }

        return Equals(otherError);
    }

    public static bool operator ==(Error? first, Error? second)
    {
        if (first is null && second is null)
        {
            return true;
        }

        if (first is null || second is null)
        {
            return false;
        }

        return first.Equals(second);
    }

    public static bool operator !=(Error? first, Error? second)
    {
        return !(first == second);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Code, Message);
    }

    public override string ToString()
    {
        return Message;
    }

    public static Error FromException<TException>(TException exception)
        where TException : Exception
    {
        if (exception is AggregateException || exception.InnerException is null)
        {
            return New(exception.GetType().Name, exception.Message);
        }

        return New(exception.GetType().Name, $"{exception.Message}. ({exception.InnerException.Message})");
    }

    public void ThrowIfErrorNone()
    {
        if (this == None)
        {
            throw new InvalidOperationException("Provided error is Error.None");
        }
    }

    public string? MessageOrNullIfErrorNone()
    {
        if (this == None)
        {
            return null;
        }

        return Message;
    }
}
