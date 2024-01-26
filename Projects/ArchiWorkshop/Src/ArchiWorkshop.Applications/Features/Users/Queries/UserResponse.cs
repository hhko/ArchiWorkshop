using ArchiWorkshop.Applications.Abstractions.CQRS;

namespace ArchiWorkshop.Applications.Features.Users.Queries;

//public sealed record UserResponse(
//    Ulid Id,
//    string Username,
//    string Email,
//    Ulid? CustomerId) 
//    : IResponse;
//    //, IHasCursor;

public sealed record UserResponse
(
    Ulid Id
)
    : IResponse;
