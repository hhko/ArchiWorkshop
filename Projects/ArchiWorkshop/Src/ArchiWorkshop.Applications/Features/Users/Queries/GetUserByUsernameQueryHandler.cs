using ArchiWorkshop.Applications.Abstractions.CQRS;
using ArchiWorkshop.Applications.Abstractions.Utilities;
using ArchiWorkshop.Applications.Features.Users.Mappings;
using ArchiWorkshop.Domains.Abstractions.Results;
using ArchiWorkshop.Domains.AggregateRoots.Users;
using ArchiWorkshop.Domains.AggregateRoots.Users.ValueObjects;
using static ArchiWorkshop.Domains.AggregateRoots.Users.Errors.DomainErrors;

namespace ArchiWorkshop.Applications.Features.Users.Queries;

internal sealed class GetUserByUserNameQueryHandler
    : IQueryHandler<GetUserByUserNameQuery, UserResponse>
{
    private readonly IValidator _validator;

    public GetUserByUserNameQueryHandler(IValidator validator)
    {
        _validator = validator;
    }

    public async Task<IResult<UserResponse>> Handle(GetUserByUserNameQuery query, CancellationToken cancellationToken)
    {
        // Input Validation
        var userNameResult = UserName.Create(query.UserName);

        _validator
            .Validate(userNameResult);

        if (_validator.IsInvalid)
        {
            return _validator.Failure<UserResponse>();
        }

        // Act
        //var user = await _userRepository
        //    .GetByUsernameAsync(usernameResult.Value, cancellationToken);
        var user = User.Create(UserId.New(), userNameResult.Value);

        // Ouput Validation
        if (user is null)
        {
            return Result.Failure<UserResponse>(Error.NotFound<User>(query.UserName));
        }

        // Mapping
        return user
            .ToResponse()
            .ToResult();
    }
}
