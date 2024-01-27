using ArchiWorkshop.Domains.Abstractions.BaseTypes;
using ArchiWorkshop.Domains.AggregateRoots.Users.Events;
using ArchiWorkshop.Domains.AggregateRoots.Users.ValueObjects;

namespace ArchiWorkshop.Domains.AggregateRoots.Users;

public class User : AggregateRoot<UserId>, IAuditable
{
    private User(UserId id, UserName userName) //, Email email)
        : base(id)
    {
        UserName = userName;
        //Email = email;
    }

    private User()
    {
    }

    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? UpdatedOn { get; set; }
    public string CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    public UserName UserName { get; set; }

    public static User Create(UserId id, UserName userName) //, Email email)
    {
        var user = new User(id, userName); //, email);
        user.RaiseDomainEvent(UserRegisteredDomainEvent.New(user.Id));
        return user;
    }
}
