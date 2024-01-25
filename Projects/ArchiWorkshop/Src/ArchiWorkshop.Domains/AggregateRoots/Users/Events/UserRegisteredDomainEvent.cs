using ArchiWorkshop.Domains.Abstractions.BaseTypes;

namespace ArchiWorkshop.Domains.AggregateRoots.Users.Events;

// Ctor: 기존 Id로 생성
public sealed record UserRegisteredDomainEvent(Ulid Id, UserId UserId) : DomainEvent(Id)
{
    // New: 새 Id로 생성
    public static UserRegisteredDomainEvent New(UserId userId)
    {
        return new UserRegisteredDomainEvent(Ulid.NewUlid(), userId);
    }
}