using ArchiWorkshop.Applications.Abstractions.CQRS;
using ArchiWorkshop.Applications.Abstractions.Utilities;
using ArchiWorkshop.Applications.Features.Users.Mappings;
using ArchiWorkshop.Domains.Abstractions.Results;
using ArchiWorkshop.Domains.AggregateRoots.Users;
using ArchiWorkshop.Domains.AggregateRoots.Users.ValueObjects;

namespace ArchiWorkshop.Applications.Features.Users.Queries;

internal sealed class GetUserByUsernameQueryHandler
    : IQueryHandler<GetUserByUsernameQuery, UserResponse>
{
    public async Task<IResult<UserResponse>> Handle(GetUserByUsernameQuery query, CancellationToken cancellationToken)
    {
        await Task.Delay(1);

        var userNameResult = UserName.Create(query.Username);
        var user = new User();

        return user
            .ToResponse()
            .ToResult();
    }
}
