using ArchiWorkshop.Domains.Abstractions.Results;
using MediatR;

namespace ArchiWorkshop.Applications.Abstractions.CQRS;

// IQueryHandler<입력 타입, 출력 타입>
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, IResult<TResponse>>
    where TQuery : IQuery<TResponse>
    where TResponse : IResponse
{
}
