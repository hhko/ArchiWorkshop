using ArchiWorkshop.Applications.Abstractions.CQRS;

namespace ArchiWorkshop.Applications.Features.Users.Queries;

// 입력 타입 : IQuery<출력 타입>
public sealed record GetUserByUsernameQuery(string UserName) : IQuery<UserResponse>;
