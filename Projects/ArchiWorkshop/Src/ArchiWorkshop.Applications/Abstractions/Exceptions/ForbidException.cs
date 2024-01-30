namespace ArchiWorkshop.Applications.Abstractions.Exceptions;

public sealed class ForbidException(string message)
    : Exception(message);