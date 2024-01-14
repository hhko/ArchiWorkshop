namespace ArchiWorkshop.Domains.Abstractions.DomainTypes;

public interface IAuditable
{
    DateTimeOffset CreatedOn { get; set; }
    DateTimeOffset? UpdatedOn { get; set; }
    string CreatedBy { get; set; }
    string? UpdatedBy { get; set; }
}
