# TODO

- 컨테이너화
- WebApi -> Validation 통합
- Validation 동영상 강의 정리
- 문서 정리

----

- WebApi 프로젝트 구성
- WebApi -> Application 레이어 구성
- MediatR Pipeline 이해
- 로그 파이프라인 이해
- 로그 LoggerMessage 속성 이해
- Validation 파이프라인 이해
- Error CreateValidationResult 메서드 이해
---
- 컨테이너화 테스트
  - 단위
  - 통합
  - 성능
- 컨테이너화
- WebApi 성능 테스트
- WebApi 통합 테스트
- WebApi
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
---

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

- ValueObject <object> 개선
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

<br/>

# DONE
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
