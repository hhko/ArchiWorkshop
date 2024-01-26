using ArchiWorkshop.Applications.Features.Users.Queries;
using ArchiWorkshop.Domains.AggregateRoots.Users.Enumerations;
using ArchiWorkshop.Domains.AggregateRoots.Users;

namespace ArchiWorkshop.Applications.Features.Users.Mappings;

internal static class UserMapping
{
    public static UserResponse ToResponse(this User user)
    {
        return new UserResponse
        (
            user.Id.Value
        //user.Username.Value,
        //user.Email.Value,
        //user.CustomerId?.Value
        );
    }
}
