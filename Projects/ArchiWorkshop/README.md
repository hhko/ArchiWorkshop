# Architecture Workshop for Domain-Driven Design 프로젝트
## 목차
- 아키텍처 구성
- 요구사항
- Continuous Integration
- 개발 구성
- 의존성 주입
- 도메인 Primitive 타입
- 도메인 Primitive Error 타임
- 도메인 Primitive Result 타입
- 패키지

<br/>

## 아키텍처 구성
### 레이어 구성 규칙
```
{솔루션}.{레이어}s.{주제}
```
- 레이어
  - Adapter
  - Application
  - Domain
- 주제
  - Presentation
  - Persistence
  - Infrastructure
  - ...

### 레이어 구성 적용
```shell
ArchiWorkshop
  # Adapter Layer
  -> ArchiWorkshop.Adapters.Presentation
  -> ArchiWorkshop.Adapters.Persistence 참조-> ArchiWorkshop.Adapters.Infrastructure

  # Application Layer
  -> ArchiWorkshop.Applications

  # Domain Layer
  -> ArchiWorkshop.Domains
```
- 솔루션: `ArchiWorkshop`
- `ArchiWorkshop.Domains` 레이어는 `ArchiWorkshop.Applications` 레이어만 참조합니다.

### 레이어 폴더 구성
![](./.images/2024-01-20-06-54-33.png)
- `AssemblyReference.cs`는 어셈블리 참조를 위한 공통 파일입니다.
- `Abstractions`는 "레이어 공통 요소"와 "개별 레이어 구성"을 위한 폴더입니다.
- `{레이어명}LayerRegistration.cs`는 인터페이스 주입 등록을 위한 파일입니다.
  ```CS
  // DI 네임스페이스를 사용하여 참조와 using 구문을 제거 시킵니다.
  //namespace ArchiWorkshop.Applications.Abstractions.Registrations;
  namespace Microsoft.Extensions.DependencyInjection;

  public static class PersistenceLayerRegistration
  {
    public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
    {
      // ...
    }
  }
  ```

<br/>

## 요구사항
- ...

<br/>

## Continuous Integration
### 폴더 구성
```
/ArchiWorkshop                                      // 솔루션 Root
    /{_N_Project_Layers}                            // 프로젝트 N개 레이어
    /TestResults                                    // 테스트 자동화 결과
        /19f5be57-f7f1-4902-a22d-ca2dcd8fdc7a       // dotnet test: 코드 커버리지 N개
            /coverage.cobertura.xml

            /merged-coverage.cobertura.xml          // dotnet-coverage: Merged 코드 커버리지

            /CodeCoverageReport                     // ReportGenerator: 코드 커버리지 Html, Badges
                /...
```

### Local CI(Build.ps1)
```shell
# 전역 도구 목록 확인하기
dotnet tool list -g

# 전역 도구 설치
dotnet tool install -g dotnet-coverage
dotnet tool install -g dotnet-reportgenerator-globaltool

# 전역 도구 업데이트
dotnet tool update -g dotnet-coverage
dotnet tool update -g dotnet-reportgenerator-globaltool

# 패키지 ID                              버전           명령
# --------------------------------------------------------------------
# dotnet-coverage                        17.9.6        dotnet-coverage
# dotnet-reportgenerator-globaltool      5.2.0         reportgenerator
```
- CI 로컬 빌드를 위해 dotnet 도구를 전역적으로 설치합니다.
  - `dotnet-coverage`
  - `dotnet-reportgenerator-globaltool`

```shell
#
# .sln 파일이 있는 곳에서 CLI 명령을 실행합니다.
#

$current_dir = Get-Location
$testResult_dir = Join-Path -Path $current_dir -ChildPath "TestResults"

# 이전 테스트 결과 정리(TestResults 폴더 정리)
if (Test-Path -Path $testResult_dir) {
    Remove-Item -Path (Join-Path -Path $testResult_dir -ChildPath "*") -Recurse -Force
}

# NuGet 패키지 복원
dotnet restore $current_dir

# 솔루션 빌드
dotnet build $current_dir --no-restore --configuration Release --verbosity m

# 솔루션 테스트
dotnet test `
    --configuration Release `
    --results-directory $testResult_dir `
    --no-build `
    --collect "XPlat Code Coverage" `
    --verbosity normal

# 코드 커버리지 머지
dotnet-coverage merge (Join-Path -Path $testResult_dir -ChildPath "**/*.cobertura.xml") `
    -f cobertura `
    -o (Join-Path -Path $testResult_dir -ChildPath "merged-coverage.cobertura.xml")

# 코드 커버리지 HTML
reportgenerator `
	-reports:(Join-Path -Path $testResult_dir -ChildPath "merged-coverage.cobertura.xml") `
	-targetdir:(Join-Path -Path $testResult_dir -ChildPath "CodeCoverageReport") `
	-reporttypes:"Html;Badges" `
  -verbosity:Info
```
- [Build.ps1](./Build.ps1)
  ```shell
  # PowerShell을 관리자 권한으로 실행
  Set-ExecutionPolicy RemoteSigned
  ```
  - PowerShell 로컬 실행시 권한 문제가 발생하면 실행 권한을 변경합니다.

### Remote CI(GitHub Actions)
- [.github/workflows/dotnet-ci.yml](https://github.com/hhko/ArchiWorkshop/blob/main/.github/workflows/dotnet-ci.yml)

![](./.images/2024-01-21-16-49-10.png)

<br/>

## 개발 구성
### Framework 참조 추가
```xml
<ItemGroup>
	<FrameworkReference Include="Microsoft.AspNetCore.App" />
</ItemGroup>
```
![](./.images/2024-01-21-01-08-07.png)
- `IWebHostEnvironment`

### 시작 프로젝트 변환
- 개요
  - Console 프로젝트 템플릿을 사용하여 WebApi 시작 프로젝트로 변환합니다.
- 변경 전
  ```xml
  <Project Sdk="Microsoft.NET.Sdk">
  ```
- 변경 후
  ```xml
  <Project Sdk="Microsoft.NET.Sdk.Web">
  ```
  - `Properties\launchSettings.json` 파일이 자동 생성됩니다.

<br/>

## 의존성 주입
```
ArchiWorkshop
    -> ArchiWorkshop.Adapters.Presentation
        -> ArchiWorkshop.Application
```
- ArchiWorkshop에서 ArchiWorkshop.Application 참조 없이 ArchiWorkshop.Application 확장 메서드 사용하기

### DI 네임스페이스 변경 전
```cs
using ArchiWorkshop.Applications.Abstractions.Registrations;

var builder = WebApplication.CreateBuilder();
builder.Services.RegisterApplicationLayer();
```
- ArchiWorkshop.Applications 참조 추가
- `using ArchiWorkshop.Applications.Abstractions.Registrations;` 구문 추가

### DI 네임스페이스 변경 후(Microsoft.Extensions.DependencyInjection)
```cs
var builder = WebApplication.CreateBuilder();
builder.Services.RegisterApplicationLayer();
```
- ~~ArchiWorkshop.Applications 참조 추가~~가 불필요하다.
- ~~`using ArchiWorkshop.Applications.Abstractions.Registrations;` 구문 추가~~가 불필요하다.
- ArchiWorkshop.Host에서 ArchiWorkshop.Application의 확장 메서드를 참조와 using 구문 추가 없이 바로 사용할 수 있다.

<br/>

## 도메인 Primitive 타입
### Primitive 타입 구성
```cs
// 1.1 ValueObject
[Serializable]
ValueObject
  : IEquatable<ValueObject>

// 1.2 Enumeration?
// TODO...

// 2.1 Entity Id
IEntityId
    : IComparable<IEntityId>
IEntityId<TEntityId>
    : IEntityId

// 2.2 Entity
IEntity
Entity<TEntityId>
    : IEquatable<Entity<TEntityId>>
    , IEntity
    where TEntityId : struct, IEntityId<TEntityId>

// 3.1 DomainEvent
IDomainEvent
    : INotification

// 3.2 AggregateRoot
IAggregateRoot
    : IEntity
AggregateRoot<TEntityId>
    : Entity<TEntityId>
    , IAggregateRoot
    where TEntityId : struct, IEntityId<TEntityId>

// 4. Auditable(Entity & AggregateRoot)
IAuditable
```
- **Value**
  - ValueObject
  - Enumeration
- **Entity**
  - IEntityId
  - IEntityId<TEntityId>
  - IEntity
  - Entity<TEntityId>
- **AggregateRoot**
  - IDomainEvent
  - IAggregateRoot
  - AggregateRoot<TEntityId>
- **Audit**
  - IAuditable

### Primitive 타입 적용
```cs
// 적용 예: Entity
Customer
    : Entity<CustomerId>
    , IAuditable

// 적용 예: AggregateRoot
User
    : AggregateRoot<UserId>
    , IAuditable
```

<br/>

## 도메인 Primitive Error 타임
### Error 타임 구성
```cs
public string Code { get; }
public string Message { get; }
```

### Error 타입 생성
- 사전 정의
  ```cs
  // 실패: 에러
  public static readonly Error NullValue = new($"{nameof(NullValue)}", "The result value is null.");
  public static readonly Error ConditionNotSatisfied = new($"{nameof(ConditionNotSatisfied)}", "The specified condition was not satisfied.");
  public static readonly Error ValidationError = new($"{nameof(ValidationError)}", "A validation problem occurred.");

  // 성공
   public static readonly Error None = new(string.Empty, string.Empty);
  ```
- From Exception
  ```cs
  public static Error FromException<TException>(TException exception)
    where TException : Exception
  ```
- 사용자 정의
  ```cs
  public static Error New(string code, string message)
  ```

<br/>

## 도메인 Primitive Result 타입
### Result 타입 구성
- 값이 없는 성공/실패: `Result`
  ```shell
  IResult
  ↑
  Result  IValidationResult
  ↑       ↑
  ValidationResult
  ```
- 값이 있는 성공/실패: `IResult<out TValue>`
  ```shell
  IResult
  ↑
  IResult<out TValue>
  ↑
  Result<TValue>  IValidationResult
  ↑               ↑
  ValidationResult<T>
  ```

### 유효성 결과 타입
- `ValidationResult, ValidationResult<T>`은 실패한 모든 유효성 검사 결과(ValidationErrors)를 포함 시킵니다.
- 유효성 검사 실패이기 때문에 Error 값은 `ValidationResult`입니다.
  - IsFailure: `true`
  - Error: `ValidationResult`
  - ValidationErrors: `N개`

### Result 타입 속성
```cs
public interface IResult
{
    bool IsSuccess { get; }

    bool IsFailure { get; }

    Error Error { get; }
}

public interface IResult<out TValue> : IResult
{
    TValue Value { get; }
}

public interface IValidationResult
{
    Error[] ValidationErrors { get; }
}
```

### Result 타입 생성
- 성공/실패를 동적으로 판단할 때
  ```cs
  // bool      : False일 때 -> ConditionNotSatisfied
  // TValue?   : NULL일 때  -> NullValue
  Create
  ```
- 성공/실패를 정적으로 판단할 때
  ```cs
  // 값이 없는 성공/실패
  Success()
  Failure(Error error)

  // 값이 있는 성공/실패
  Success<TValue>(TValue value)
  Failure<TValue>(Error error)
  ```

### ValidationResult 타입 생성
- 성공/실패를 동적으로 판단할 때: Error 타입 컬랙션(this ICollection<Error> errors)에서 생성합니다.
  ```cs
  public static class ErrorUtilities
  {
    public static TResult CreateValidationResult<TResult>(
      this ICollection<Error> errors)
      where TResult : class, IResult

    public static ValidationResult<TValueObject> CreateValidationResult<TValueObject>(
      this ICollection<Error> errors,
      Func<TValueObject> createValueObject)
      where TValueObject : ValueObject
  }
  ```
- 성공/실패를 정적으로 판단할 때
  ```cs
  // 값이 없는 성공/실패
  WithoutErrors()
  WithErrors(Error[] validationErrors)

  // 값이 있는 성공/실패
  WithoutErrors(TValue? value)
  WithErrors(Error[] validationErrors)
  ```

<br/>

## 패키지
```shell
# 도메인
- Ulid
- MediatR.Contracts

# 테스트
- Microsoft.NET.Test.Sdk
- xunit
- FluentAssertions

# 테스트 아키텍처
- NetArchTest.Rules

# 테스트 데이터
- Bogus
```