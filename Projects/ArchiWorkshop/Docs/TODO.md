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
Utilities       // 더 명확한 이름(확장 메서드, 정적 메서드: using static)


New			// ?
Create		// 외부
```

-------------------------

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