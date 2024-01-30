namespace ArchiWorkshop.Applications.Abstractions.Exceptions;

public sealed class BadRequestException(string message)
    : Exception(message);
