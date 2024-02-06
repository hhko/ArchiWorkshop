```
1주: 2월 3일(금)
  - [x] 로그
  - [x] Pipeline vs Middleware 비교
  - [x] Pipeline vs Middleware 이동? Application -> Presentation
  - [ ] Api 문서화
    IExamplesProvider
  - [ ] Api 버전화
  - [ ] TreatWarningsAsErrors, https://learn.microsoft.com/ko-kr/dotnet/csharp/language-reference/compiler-options/errors-warnings
  ---
  - [ ] 컨테이너화
  - [ ] HealthCheck
  ---
  - [ ] Serilog.Exceptions과 LogMessage 통합?
  - [ ] Api 타입 세이프, https://github.com/reactiveui/refit
  - [ ] 유효성 검사 FluentValidation 통합
  - [ ] 유효성 실패일 때 현재 값 포함
  - [ ] 유효성 실패 메시지 다국어?
  ---
  - [ ] GitHub 코드 정적 분석
2주: 2월 10일(금)
  - 통합 테스트 자동화
  - 성능 테스트 자동화
  - 컨테이너 기반 테스트 자동화
  - BDD
3주: 2월 17일(금)
  - EF
4주: 2월 24일(금)
5주: 3월 2일(금)
```

- console docker: https://learn.microsoft.com/ko-kr/dotnet/core/docker/build-container?tabs=windows&pivots=dotnet-8-0
- asp.net docker: https://learn.microsoft.com/ko-kr/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-8.0

# TODO

- WebApi + Mediator(Pipeline: Validation, Log)
  - [x] 파이프라인 이해
  - [x] IValidator 인터페이스 이해
  - [x] 로그 구성
  - [x] 로그 LoggerMessage 속성 이해
  - [ ] Error CreateValidationResult 메서드 이해
  - [ ] Controller 실패 처리

```
public sealed class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
public sealed class RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger) : IMiddleware
```

using Microsoft.Extensions.Logging;

[LoggerMessage
(
    EventId = 1,
    EventName = $"StartingRequest in {nameof(LoggingPipeline<IRequest<IResult>, IResult>)}",
    Level = LogLevel.Information,
    Message = "Starting request {RequestName}, {DateTimeUtc}",
    SkipEnabledCheck = false
)]
public static partial void LogStartingRequest(this ILogger logger, string requestName, DateTime dateTimeUtc);

partial class LoggerMessageDefinitionsUtilities
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Extensions.Logging.Generators", "8.0.9.3103")]
    private static readonly global::System.Action<global::Microsoft.Extensions.Logging.ILogger, global::System.String, global::System.DateTime, global::System.Exception?> __LogStartingRequestCallback =
        global::Microsoft.Extensions.Logging.LoggerMessage.Define<global::System.String, global::System.DateTime>(global::Microsoft.Extensions.Logging.LogLevel.Information, new global::Microsoft.Extensions.Logging.EventId(1, "StartingRequest in LoggingPipeline"), "Starting request {RequestName}, {DateTimeUtc}", new global::Microsoft.Extensions.Logging.LogDefineOptions() { SkipEnabledCheck = true }); 

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Extensions.Logging.Generators", "8.0.9.3103")]
    public static partial void LogStartingRequest(this global::Microsoft.Extensions.Logging.ILogger logger, global::System.String requestName, global::System.DateTime dateTimeUtc)
    {
        if (logger.IsEnabled(global::Microsoft.Extensions.Logging.LogLevel.Information))
        {
            __LogStartingRequestCallback(logger, requestName, dateTimeUtc, null);
        }
    }
}

---

- CI Codecov 적용

---

- 컨테이너화
- 컨테이너화 단위 테스트
- 컨테이너화 데이터베이스 통합 테스트
- 컨테이너화 성능 테스트
- 컨테이너화 CI?

---

- 코드 정적 분석: sonar-cloud
- 코드 정적 분석: codeql-analysis.yml
  - https://github.com/jeangatto/ASP.NET-Core-Clean-Architecture-CQRS-Event-Sourcing/tree/main/.github/workflows

```
# https://zeddios.tistory.com/1047
{계정} > Settings > Developer settings > Personal access tokens > Tokens (classic)
  Generate new token

{저장소} > Settings > Secrets > New Secret
```

---

- 문서 정리


- DI decorator

---
- Address 적용
- FistName 적용
- Email 유효성 검사 테스트 자동화, Bogus
  - 공백
  - 길이
  - 형식
- Domain 레이어 Abstractions 테스트 추가
- Entity
- <out T> 이해

```
// 파일
Xyz             // 핵심 메서드
XyzUtilities	// 그외 메서드

// 폴더
Utilities  // 더 명확한 이름(확장 메서드, 정적 메서드: using static)
  폴더 존재 유: 공용 Utilities
  폴더 존재 무: 전용 Utilities

New			// ?
Create		// 외부
```

- `public readonly record struct UserId : IEntityId<UserId>` xxxId 구현 단순화하기, 반복적 코드가 많다.
- 코드 커버리지 | ArchiWorkshop.Tests.Unit 코드 커버리지 제외
- 코드 커버리지 | N개 테스트일 때 통합 코드 커버리지 구하기
- ValueObject | `public abstract IEnumerable<object> GetAtomicValues();` object 제거하기
  - `protected` override IEnumerable<object> GetAtomicValues()
  - protected abstract IEnumerable<`IComparable`> GetEqualityComponents();
- FluentValidation DI에서 `includeInternalTypes` 이해
  ```cs
  services.AddValidatorsFromAssembly(
      ArchiWorkshop.Applications.AssemblyReference.Assembly,
      includeInternalTypes: true);
  ``````
- MediatR + FluentValidation 전체 라이프사이클을 이해한다.
  - https://code-maze.com/cqrs-mediatr-fluentvalidation/
- Error 클래스 `CreateValidationResult` 구현을 이해한다.
  ```cs
  object validationResult = typeof(ValidationResult<>)
    .GetGenericTypeDefinition()
    .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
    .GetMethod(nameof(ValidationResult.WithErrors))!
    .Invoke(null, [errors])!;
  ```
- Error 클래스 `UseValidation` 구현을 이해한다.
- 빌드
  ```
  - name: Upload coverage to Codecov
        uses: codecov/codecov-action@v3
        with:
          token: ${{ secrets.CODE_COV_TOKEN }}
  ```

---

- gRPC 통합 테스트: https://renatogolia.com/2021/12/19/testing-asp-net-core-grpc-applications-with-webapplicationfactory/

Two-stage initialization
https://github.com/serilog/serilog-aspnetcore?tab=readme-ov-file#two-stage-initialization
the ASP.NET Core host, including the appsettings.json configuration and dependency injection, aren't available yet.



Write to different log files by level
https://ehye.github.io/2023/02/14/asp-dotnet-core-api-serilog/


{
    "@t": "2024-01-28T08:01:05.3490315Z",
    "@mt": "Failed to determine the https port for redirect.",
    "@l": "Warning",
    "@tr": "c4c6d285f7f862cad578f11a2dab08f6",
    "@sp": "64daae1c0410fe79",
    "EventId": {
        "Id": 3,
        "Name": "FailedToDeterminePort"
    },
    "SourceContext": "Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware",
    "RequestId": "0HN0VQT2R1V5G:00000001",
    "RequestPath": "/",
    "ConnectionId": "0HN0VQT2R1V5G",
    "MachineName": "HHKO-LABTOP",
    "ProcessId": 19968,
    "ThreadId": 12
}
{
    "@t": "2024-01-28T08:02:16.0945267Z",
    "@mt": "테스트",
    "@tr": "8a524c53c007f0ece499959328d59b85",
    "@sp": "260b04e1c71e0a61",
    "SourceContext": "ArchiWorkshop.Applications.Abstractions.Pipelines.LoggingPipeline",
    "ActionId": "b7ac7be6-03ae-4df6-ad3f-915677998f8c",
    "ActionName": "ArchiWorkshop.Adapters.Presentation.Controllers.UsersController.GetUserByUsername (ArchiWorkshop.Adapters.Presentation)",
    "RequestId": "0HN0VQT2R1V5I:00000001",
    "RequestPath": "/api/users/foo",
    "ConnectionId": "0HN0VQT2R1V5I",
    "MachineName": "HHKO-LABTOP",
    "ProcessId": 19968,
    "ThreadId": 9
}
{
    "@t": "2024-01-28T08:02:16.1001772Z",
    "@mt": "Starting request {RequestName}, {DateTimeUtc}",
    "@tr": "8a524c53c007f0ece499959328d59b85",
    "@sp": "260b04e1c71e0a61",
    "RequestName": "GetUserByUsernameQuery",
    "DateTimeUtc": "2024-01-28T08:02:16.0954273Z",
    "EventId": {
        "Id": 1,
        "Name": "StartingRequest in LoggingPipeline"
    },
    "SourceContext": "ArchiWorkshop.Applications.Abstractions.Pipelines.LoggingPipeline",
    "ActionId": "b7ac7be6-03ae-4df6-ad3f-915677998f8c",
    "ActionName": "ArchiWorkshop.Adapters.Presentation.Controllers.UsersController.GetUserByUsername (ArchiWorkshop.Adapters.Presentation)",
    "RequestId": "0HN0VQT2R1V5I:00000001",
    "RequestPath": "/api/users/foo",
    "ConnectionId": "0HN0VQT2R1V5I",
    "MachineName": "HHKO-LABTOP",
    "ProcessId": 19968,
    "ThreadId": 9
}
{
    "@t": "2024-01-28T08:02:16.1336739Z",
    "@mt": "Request completed {requestName}, {DateTimeUtc}",
    "@tr": "8a524c53c007f0ece499959328d59b85",
    "@sp": "260b04e1c71e0a61",
    "requestName": "GetUserByUsernameQuery",
    "DateTimeUtc": "2024-01-28T08:02:16.1333871Z",
    "EventId": {
        "Id": 2,
        "Name": "CompletingRequest in LoggingPipeline"
    },
    "SourceContext": "ArchiWorkshop.Applications.Abstractions.Pipelines.LoggingPipeline",
    "ActionId": "b7ac7be6-03ae-4df6-ad3f-915677998f8c",
    "ActionName": "ArchiWorkshop.Adapters.Presentation.Controllers.UsersController.GetUserByUsername (ArchiWorkshop.Adapters.Presentation)",
    "RequestId": "0HN0VQT2R1V5I:00000001",
    "RequestPath": "/api/users/foo",
    "ConnectionId": "0HN0VQT2R1V5I",
    "MachineName": "HHKO-LABTOP",
    "ProcessId": 19968,
    "ThreadId": 9
}

<br/>

# DONE
- `2024-01-31(수)` Pipeline vs Middleware 이동? Application -> Presentation
- `2024-01-30(화)` Api Problem 객체 생성
- `2024-01-28(토)` WebApi Controller Dll 프로젝트 만들기
- `2024-01-27(금)` MediatR UseCase Query 구현
- `2024-01-26(목)` 환경설정 읽기
- `2024-01-25(수)` Enumeration 값 객체 구현
- `2024-01-20(토)` Application Layer 로그 파이프라인
- `2024-01-20(토)` DI 구조화 이해
- `2024-01-14(일)` Entity 클래스 구현
- `2024-01-14(일)` IDomainEvent 인터페이스 구현
- `2024-01-14(일)` IAggregateRoot 인터페이스 구현
- `2024-01-14(일)` `IX, IX<T> : IX` T타입 생성을 위한 자료구조
  ```cs
  IEntityId
  IEntityId<T> : IEntityId
  ```
- `2024-01-14(일)` EntityIdConverter 이해(현재 버전에는 제외 시킴)
- `2024-01-14(일)` IEntityId 구현
- `2024-01-14(일)` Error -> Result 폴더와 통합
- `2024-01-14(일)` 레이어 기본 프로젝트 생성 
- `2024-01-13(토)` Bogus 기반으로 Email 테스트 성공
- `2024-01-13(토)` Result 타입
- `2024-01-13(토)` Build.ps1
- `2024-01-12(금)` GitHub Actions 구현
- `2024-01-10(수)` ValueObject 아키텍처 테스트 추가
  - 상속 클래스는 불변이어야 한다.
  - 상속 클래스는 Create 메서드를 가져야 한다.
- `2024-01-10(수)` ValueObject 기본 소스 추가
- `2024-01-10(수)` 어셈블리 구분 클래스 추가
