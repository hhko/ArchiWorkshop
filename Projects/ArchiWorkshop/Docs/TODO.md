- 컨테이너화 테스트
  - 단위
  - 통합
  - 성능
- 컨테이너화
- WebApi 성능 테스트
- WebApi 통합 테스트
- WebApi
- Entity
- Address 적용
- FistName 적용
- Email 유효성 검사 테스트 자동화, Bogus
  - 공백
  - 길이
  - 형식
  ```cs
  var faker = new Faker();
  var email = faker.Person.Email;
  ```

---

```
// 파일
Xyz				// 핵심 메서드
XyzUtilities	// 그외 메서드

// 폴더
Utilities		// 더 명확한 이름(확장 메서드, 정적 메서드)
```

- `2024-01-13(토)` Bogus 기반으로 Email 테스트 성공
- `2024-01-13(토)` Result 타입
- `2024-01-13(토)` Build.ps1
- `2024-01-12(금)` GitHub Actions 구현
- `2024-01-10(수)` ValueObject 아키텍처 테스트 추가
  - 상속 클래스는 불변이어야 한다.
  - 상속 클래스는 Create 메서드를 가져야 한다.
- `2024-01-10(수)` ValueObject 기본 소스 추가
- `2024-01-10(수)` 어셈블리 구분 클래스 추가