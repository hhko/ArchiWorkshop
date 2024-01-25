namespace ArchiWorkshop.Domains.Abstractions.BaseTypes;

public abstract record class DomainEvent(Ulid Id) : IDomainEvent;
