using ArchiWorkshop.Applications.Abstractions.CQRS;
using ArchiWorkshop.Applications.Abstractions.Utilities;
using ArchiWorkshop.Applications.Features.Users.Mappings;
using ArchiWorkshop.Domains.Abstractions.Results;
using ArchiWorkshop.Domains.AggregateRoots.Users;
using ArchiWorkshop.Domains.AggregateRoots.Users.ValueObjects;
using static ArchiWorkshop.Domains.AggregateRoots.Users.Errors.DomainErrors;

namespace ArchiWorkshop.Applications.Features.Users.Queries;

internal sealed class GetUserByUsernameQueryHandler
    : IQueryHandler<GetUserByUsernameQuery, UserResponse>
{
    public async Task<IResult<UserResponse>> Handle(GetUserByUsernameQuery query, CancellationToken cancellationToken)
    {
        await Task.Delay(1);

        ValidationResult<UserName> usernameResult = UserName.Create(query.UserName);
        var user = User.Create(UserId.New(), usernameResult.Value);

        //bool emailIsTaken = await _userRepository
        //    .IsEmailTakenAsync(emailResult.Value, cancellationToken);

        //_validator
        //    .Validate(emailResult)
        //    .Validate(usernameResult)
        //    .Validate(passwordResult)
        //    .If(emailIsTaken, thenError: EmailError.EmailAlreadyTaken);

        //if (_validator.IsInvalid)
        //{
        //    return _validator.Failure<RegisterUserResponse>();
        //}

        return user
            .ToResponse()
            .ToResult();
    }
}
