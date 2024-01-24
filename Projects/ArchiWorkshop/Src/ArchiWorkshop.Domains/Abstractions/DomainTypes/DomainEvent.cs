namespace ArchiWorkshop.Domains.Abstractions.DomainTypes;

public abstract record class DomainEvent(Ulid Id) : IDomainEvent;
