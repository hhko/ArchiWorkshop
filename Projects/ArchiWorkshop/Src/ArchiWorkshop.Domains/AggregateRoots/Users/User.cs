using ArchiWorkshop.Domains.Abstractions.BaseTypes;

namespace ArchiWorkshop.Domains.AggregateRoots.Users;

public class User : AggregateRoot<UserId>, IAuditable
{
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? UpdatedOn { get; set; }
    public string CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
}
