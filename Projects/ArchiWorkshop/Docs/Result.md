# 성공/실패 타입

```cs
값이 없는 타입                  vs   값이 있는 타입
IResult                             IResult
↑                                   ↑
|                                   IResult<out TValue>
|                                   ↑
Result                              Result<TValue>
↑       IValidationResult           ↑       IValidationResult
|       ↑                           |       ↑
ValidationResult                    ValidationResult<T>

성공                                성공-값
실패-에러                           실패-에러

실패-에러,에러s                     실패-에러,에러s       // 타입: ValidationResult
                                                        // 에러: Error.ValidationError
```

## 주요 인터페이스
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

## Result 타입
### Result 자료구조
```cs
IResult                 IResult<out TValue>
Result                  Result<TValue>
성공                    성공-값
실패-에러               실패-에러
```

### Result 생성 정적 메서드
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

## ValidationResult
### ValidationResult 자료구조
```cs
ValidationResult        ValidationResult<TValue>
성공                    성공-값
실패-에러,에러s          실패-에러,에러s
// 에러: Error.ValidationError
```

### ValidationResult 생성 정적 메서드
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

## 에러 종류
- NullValue
- ConditionNotSatisfied
- ValidationError
