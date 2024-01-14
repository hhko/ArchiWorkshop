using MediatR;

namespace ArchiWorkshop.Domains.Abstractions.DomainTypes;

public interface IDomainEvent
    : INotification
{
    Ulid Id { get; init; }
}
