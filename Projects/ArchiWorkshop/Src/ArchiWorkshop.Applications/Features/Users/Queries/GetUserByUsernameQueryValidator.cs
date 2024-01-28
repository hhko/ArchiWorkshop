using FluentValidation;

namespace ArchiWorkshop.Applications.Features.Users.Queries;

internal sealed class GetUserByUserNameQueryValidator : AbstractValidator<GetUserByUserNameQuery>
{
    public GetUserByUserNameQueryValidator()
    {
        RuleFor(x => x.UserName).NotNull(); //.MinimumLength(5);
    }
}