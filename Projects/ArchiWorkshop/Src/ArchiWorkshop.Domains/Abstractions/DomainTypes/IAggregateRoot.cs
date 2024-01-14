namespace ArchiWorkshop.Domains.Abstractions.DomainTypes;

public interface IAggregateRoot
    : IEntity
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
}
