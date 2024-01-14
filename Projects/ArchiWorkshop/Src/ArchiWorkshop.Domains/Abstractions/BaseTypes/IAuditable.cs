﻿namespace ArchiWorkshop.Domains.Abstractions.BaseTypes;

public interface IAuditable
{
    DateTimeOffset CreatedOn { get; set; }
    DateTimeOffset? UpdatedOn { get; set; }
    string CreatedBy { get; set; }
    string? UpdatedBy { get; set; }
}
