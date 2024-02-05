- [ ] 레이어 구성
  - 어셈블리
  - DI 등록
- [ ] WebApi 버전
- [ ] WebApi 버전 문서화
  - 정보
  - 테마
  - 버전
- [ ] WebApi 버전 문서화 IOperationFilter
- [ ] Result 타입/ValidationResult 타입
- [ ] 도메인 타입
- [ ] MediatR CQRS 인터페이스
- [ ] MediatR Pipeline(Logging, FluentValidation)
- [ ] FluentValidation 도메인 모델 통합
- [ ] ASP.NET Core ProblemDetails
- [ ] ASP.NET Core Middleware
- [ ] .NET Option
- [ ] .NET Option FluentValidation
---
- [ ] Mapping
---
- [ ] 모니터링 기본
  ```
  Logs    -> otel-collector -> data-propper -> opensearch -> dashboards
  Metrics
  ```
- [ ] traces

```
IQueryable          vs. IEnumerable
IHttpActionResult   vs. IActionResult

https://learn.microsoft.com/ko-kr/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2

ASP.NET Web API 2에서 특성 라우팅을 사용하여 REST API 만들기
https://learn.microsoft.com/ko-kr/aspnet/web-api/overview/web-api-routing-and-actions/create-a-rest-api-with-attribute-routing

작업	                              예제 URI
---------------------------------------------------------------------------------------------------------------
                                     /api/books
    [Route("")]
ID로 책을 가져옵니다.	               /api/books/1
    [Route("{id:int}")]
    [ResponseType(typeof(BookDto))]
책의 세부 정보를 가져옵니다.	        /api/books/1/details
장르별 책 목록을 가져옵니다.	        /api/books/fantasy
발행일별로 책 목록을 가져옵니다.	    /api/books/date/2013-02-16 /api/books/date/2013/02/16(대체 양식)
특정 저자의 책 목록을 가져옵니다.	    /api/authors/1/books

[HttpPost]
[HttpPut]
---
[HttpGet]
---
[HttpDelete]
---
[HttpHead]
[HttpOptions]
[HttpPatch]
---
[AcceptVerbs]


- [Route("api/[controller]")]
- [Produces("application/json")]
- [ProducesResponseType<OrderHeaderResponse>(StatusCodes.Status200OK)]

// Get
- [HttpGet()]
- [HttpGet("{id}")], [FromRoute] OrderHeaderId id

// Post
- [HttpPost]
- [HttpPost("batch/upsert/{orderHeaderId}")]

// Delete
- [HttpDelete("{id}")]
- [HttpDelete($"{{orderHeaderId}}/{OrderLines}/{{orderLineId}}")]

// Patch
- [HttpPatch("{id}")]

// 변수
public const string Reviews = nameof(Reviews);

[HttpPost($"{{productId}}/{Reviews}")]
public async Task<IActionResult> AddReview([FromRoute] ProductId productId,
```