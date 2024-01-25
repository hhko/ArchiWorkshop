using MediatR;

namespace ArchiWorkshop.Domains.Abstractions.BaseTypes;

public interface IDomainEvent
    : INotification
{
    Ulid Id { get; init; }
}
