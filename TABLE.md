## 솔루션 구성
```
솔루션 프로젝트 구성
- 레이어: T1_T2_T3
- 테스트: T1_T2_T3
  - T3: 테스트 종류
    - 단위
    - 통합
    - 통합(행위: BDD)
    - Functional
    - 성능
    - Arrange 데이터: Fake
    - Arrange 생성자: 변화 차단
    - API Signature(PublicApiGenerator)

솔루션 설정 구성
- 형상관리
  - .gitattributes
  - .gitignore
- 코딩 스타일
  - .editorconfig
- 빌드  
  - Directory.Build.props
  - Directory.Build.targets
  - Directory.Packages.props
- VSCode  
  - extensions.json
  - launch.json
  - settings.json
  - tasks.json

솔루션 빌드
- 빌드
  - 로컬: build.ps1
  - 원격: GitHub Actions
- 코드 정적 분석
- 코드 형식(Format)
- 테스트
  - 코드 커버리지  

솔루션 디버깅
- Host
- Docker
- WSL
- Linux Remote

솔루션 배포
- 컨테이너
- NuGet

솔루션 문서 시스템
- DocFx/...?
- C4
- Context Mapper

솔루션 관찰(Observability) 시스템  
- 로그
- 자원
- 추적
```

- 로그
- 추적
- 통합 테스트
  - Backend
    - WebApi
    - gRPC
    - IHostedService
    - EFCore
  - Frontend
    - Web 화면
    - Desktop 화면
    - HttpClient
    - ...