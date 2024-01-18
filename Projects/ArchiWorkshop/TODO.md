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