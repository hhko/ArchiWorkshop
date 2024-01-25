using ArchiWorkshop.Domains.Abstractions.Results;
using MediatR;

namespace ArchiWorkshop.Applications.Abstractions.CQRS;

// 요청: IRequest
// 요청 결과: IResult<TResponse>
// 요청 결과 조건: where TResponse : IResponse
public interface IQuery<out TResponse> : IRequest<IResult<TResponse>>
    where TResponse : IResponse
{
}
