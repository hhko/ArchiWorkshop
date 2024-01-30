namespace ArchiWorkshop.Applications.Abstractions.Exceptions;

public sealed class NotFoundException(string message) 
    : Exception(message);