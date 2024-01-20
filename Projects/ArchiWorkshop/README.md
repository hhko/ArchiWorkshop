# Architecture Workshop for Domain-Driven Design 프로젝트

## 아키텍처 구성
### 레이어 프로젝트 구성
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

### 레이어 프로젝트 구성 예
```shell
ArchiWorkshop
  # Adapter Layer
  참조-> ArchiWorkshop.Adapters.Presentation
  참조-> ArchiWorkshop.Adapters.Persistence 참조-> ArchiWorkshop.Adapters.Infrastructure

  # Application Layer
  참조-> ArchiWorkshop.Applications

  # Domain Layer
  참조-> ArchiWorkshop.Domains
```
- `ArchiWorkshop.Applications` 레이어만 `ArchiWorkshop.Domains` 레이어를 참조합니다.

### 레이어 폴더 구성
![](./.images/2024-01-20-06-54-33.png)
- `AssemblyReference.cs`: 네임스페이스 기준으로 어셈블리를 참조할 수 있도록 표준화한다.
- `Abstractions` 폴더는 레이어 공통 요소와 개별 레이어 구성을 위한 파일을 관리합니다. 
- `{레이어명}LayerRegistration.cs`: 레이어 단위로 DI을 수행한다.
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

## 요구사항
- ...

<br/>

## 개발 환경
- [코드 커버리지](./Docs/CodeCoverage.md)

<br/>

## Framework 참조 추가
```xml
<ItemGroup>
	<FrameworkReference Include="Microsoft.AspNetCore.App" />
</ItemGroup>
```
![](./.images/2024-01-21-01-08-07.png)
- `IWebHostEnvironment`

<br/>

## 시작 프로젝트 변환
- Console 프로젝트 템플릿을 사용하여 WebApi 시작 프로젝트로 변환합니다.

### 프로젝트 파일 타입 변경
- 변경 전
  ```xml
  <Project Sdk="Microsoft.NET.Sdk">
  ```
- 변경 후
  ```xml
  <Project Sdk="Microsoft.NET.Sdk.Web">
  ```
  - `Properties\launchSettings.json` 파일이 자동 생성됩니다.


## DI 네임스페이스 활용
```
ArchiWorkshop
    참조-> ArchiWorkshop.Adapters.WebApi
        참조-> ArchiWorkshop.Application
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

## 도메인 기본 타입
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

// 4. Entity & AggregateRoot
IAuditable
```
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

## 도메인 Error 타입
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

### Error에서 IResult 타입 생성
```cs
public static TResult CreateValidationResult<TResult>(this ICollection<Error> errors)
  where TResult : class, IResult

public static ValidationResult<TValueObject> CreateValidationResult<TValueObject>(
  this ICollection<Error> errors,
  Func<TValueObject> createValueObject) 
  where TValueObject : ValueObject
```

<br/>

## 도메인 Result 타입
### Result 구조
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

### Result 속성
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

### Result 생성
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

### ValidationResult 생성
- ~~성공/실패를 동적으로 판단할 때~~
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

