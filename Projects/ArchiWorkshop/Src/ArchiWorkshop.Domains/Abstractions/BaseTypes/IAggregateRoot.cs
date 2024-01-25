namespace ArchiWorkshop.Domains.Abstractions.BaseTypes;

public interface IAggregateRoot
    : IEntity
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
}
