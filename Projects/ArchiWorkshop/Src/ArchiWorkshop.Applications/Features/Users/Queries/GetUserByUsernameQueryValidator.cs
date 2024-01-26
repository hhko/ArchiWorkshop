using FluentValidation;

namespace ArchiWorkshop.Applications.Features.Users.Queries;

internal sealed class GetUserByUsernameQueryValidator : AbstractValidator<GetUserByUsernameQuery>
{
    public GetUserByUsernameQueryValidator()
    {
        RuleFor(x => x.Username).NotNull();
    }
}